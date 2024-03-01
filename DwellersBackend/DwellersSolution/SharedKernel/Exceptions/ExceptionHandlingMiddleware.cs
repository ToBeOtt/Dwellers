using FluentValidation;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using SharedKernel.Exceptions.Common;
using System.Net;
using System.Text.Json;

namespace SharedKernel.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ContentType = "application/json";

        private static readonly JsonSerializerOptions DefaultWebOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logLevel = GetLoggerLevel(ex);
                Log.Logger.Write(logLevel, ex, "Exception has been thrown");

                httpContext.Response.ContentType = ContentType;
                httpContext.Response.StatusCode = GetHttpStatusCode(ex);

                var exceptionMessage = FormatErrorMessage(ex);

                // Serialize the error response object directly to the response stream
                await JsonSerializer.SerializeAsync(httpContext.Response.Body, exceptionMessage, DefaultWebOptions);
            }
        }

        private static ErrorResponse FormatErrorMessage(Exception ex) =>
            ex switch
            {

                DwellersDomainException domainException =>
                    new ErrorResponse(domainException.ExceptionCode, domainException.Message),

                DwellersAppException appException => new ErrorResponse(appException.ExceptionCode,
                    appException.Message),
                _ => new ErrorResponse(-1, ex.Message),
            };

        private static int GetHttpStatusCode(Exception ex)
            => ex switch
            {
                DwellersDomainException _ => (int)HttpStatusCode.BadRequest,
                DwellersAppException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

        private static LogEventLevel GetLoggerLevel(Exception ex)
            => ex switch
            {
                DwellersDomainException _ => LogEventLevel.Information,
                DwellersAppException _ => LogEventLevel.Information,
                _ => LogEventLevel.Error
            };
    }
}
