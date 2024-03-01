namespace SharedKernel.Exceptions
{
    public abstract class DwellersDomainException : Exception
    {
        public int ExceptionCode { get; }
        public DwellersDomainException(string message, int exceptionCode) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }
}
