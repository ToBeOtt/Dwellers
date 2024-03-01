using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Status
    {
        Pending,
        Initialized,
        Done
    }

    public class BulletinStatus : BaseEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        private BulletinStatus() { }
        private BulletinStatus(string statusValue)
        {
            var status = ConvertPriorityFromUIValue(statusValue);
            Status = status;
        }

        public static class BulletinStatusFactory
        {
            public static BulletinStatus CreateNewStatus(string strStatusValue)
            {
                return new BulletinStatus(strStatusValue);
            }
        }

        internal void ModifyBulletinStatus(Status status, Bulletin bulletin)
        {
            DwellerValidation(new StatusHasNotChanged(Status, status));

            Status = status;
            if(status == Status.Done)
            {
                //var @event = new BulletinStatusChangedToDoneDomainEvent(bulletin);
                //this.AddDomainEvent(@event);
            }
        }

        internal void ConvertStatusFromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Status), dbValue))
            {
                Status = (Status)dbValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }

        internal static Status ConvertPriorityFromUIValue(string uiValue)
        {
            if (int.TryParse(uiValue, out int parsedvalue) && 
                Enum.IsDefined(typeof(Status), parsedvalue))
            {
                return (Status)parsedvalue;
            }
            throw new ArgumentException("Invalid value for priority");
        }
    }
}