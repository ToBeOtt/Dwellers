namespace SharedKernel.Exceptions
{
    public abstract class DwellersAppException : Exception
    {
        public int ExceptionCode { get; }

        protected DwellersAppException(string message, int exceptionCode) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }

    public class NotFoundException : DwellersAppException
    {
        public NotFoundException(string entityId, string entityType) : base($"Entity {entityType} {entityId} was not found.", 9000)
        {

        }
    }

    public class NameRequiredException : DwellersAppException
    {
        public NameRequiredException() : base("User name is required.", 100)
        {
        }
    }

    public class ApplicationValidationError : DwellersAppException
    {
        public List<string> ValidationMessages { get; set; }
        protected ApplicationValidationError(string message, int exceptionCode) : base(message, exceptionCode)
        {
        }
    }
    
}
