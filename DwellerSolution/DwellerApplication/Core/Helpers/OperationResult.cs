namespace DwellerApplication.Core.Helpers
{
    public class OperationResult<T>
    {
        public OperationOutcome Outcome { get; set; }
        public T? Value { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
