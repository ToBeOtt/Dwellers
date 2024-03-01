using SharedKernel.Exceptions;

namespace Dwellers.Common.Application.Domain.Exceptions
{
    public class NotValidNameException : DwellersAppException
    {
        public NotValidNameException() : base("Name is required.", 400)
        {
        }
    }
}
