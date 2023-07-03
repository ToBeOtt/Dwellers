namespace DwellerApplication.Application.Services.Common
{
    public class ErrorServices
    {
        public enum OperationOutcome
        {
            Success,
            Failure,
            NotFound,
            InvalidInput
        }

        public class OperationResult<T>
        {
            public OperationOutcome Outcome { get; set; }
            public T Data { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
