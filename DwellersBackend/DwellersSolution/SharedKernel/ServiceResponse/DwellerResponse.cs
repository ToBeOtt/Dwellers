using Microsoft.Extensions.Logging;

namespace SharedKernel.ServiceResponse
{
    public class DwellerResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public Task<DwellerResponse<T>> ErrorResponse(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
            return Task.FromResult(this);
        }

        public Task<DwellerResponse<T>> SuccessResponse(T data = default)
        {
            IsSuccess = true;
            Data = data;
            return Task.FromResult(this);
        }
    }
}
