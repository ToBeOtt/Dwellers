using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins.Rules
{
    public class StatusHasNotChanged : IBusinessRule
    {
        private readonly Status _oldStatus;
        private readonly Status _newStatus;
      
        internal StatusHasNotChanged(Status oldStatus, Status newStatus)
        {
            _oldStatus = oldStatus;
            _newStatus = newStatus;   
        }

        public bool IsBroken()
        {
            return _oldStatus == _newStatus;
        }
        
        public string Message => "Status of bulletin has not changed.";
    }
}
