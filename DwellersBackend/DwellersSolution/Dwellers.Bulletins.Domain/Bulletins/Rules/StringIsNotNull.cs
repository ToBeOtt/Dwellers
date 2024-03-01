using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins.Rules
{
    public class StringIsNotNull : IBusinessRule
    {
        private readonly string _strValue;
      
        internal StringIsNotNull(string strValue)
        {
            _strValue = strValue;  
        }

        public bool IsBroken()
        {
            return _strValue == null;
        }
        
        public string Message => "There is no value attached to command.";
    }
}
