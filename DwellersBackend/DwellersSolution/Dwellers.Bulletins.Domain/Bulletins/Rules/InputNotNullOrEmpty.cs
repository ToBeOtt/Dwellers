using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins.Rules
{
    public class InputNotNullOrEmpty<T> : IBusinessRule where T : class
    {
        private readonly T _valueToCheck;

        internal InputNotNullOrEmpty(T valueToCheck)
        {
            _valueToCheck = valueToCheck;
        }

        public bool IsBroken()
        {
            if (_valueToCheck == null) return true;

            if (_valueToCheck is string stringValue)
            {
                return string.IsNullOrEmpty(stringValue);
            }
            return false; 
        }

        public string Message => "Input value is null or empty.";
    }
}
