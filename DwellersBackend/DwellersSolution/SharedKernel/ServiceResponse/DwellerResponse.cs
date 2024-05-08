using Microsoft.Extensions.Logging;

namespace SharedKernel.ServiceResponse
{
    public class DwellerResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; } 
        public bool? UserInfo { get; set; } = false;

        public Task<DwellerResponse<T>> ErrorResponse(string message, bool? userInfo)
        {
            IsSuccess = false;
            ErrorMessage = message;
            UserInfo = userInfo ?? false;
            return Task.FromResult(this);
        }

        public Task<DwellerResponse<T>> ErrorResponse(string message)
        {
            return ErrorResponse(message, false); // Default to false userInfo, so we dont have to rewrite alot of the code as of now
        }
        public Task<DwellerResponse<T>> SuccessResponse(T data = default)
        {
            IsSuccess = true;
            Data = data;
            return Task.FromResult(this);
        }
    }
}
