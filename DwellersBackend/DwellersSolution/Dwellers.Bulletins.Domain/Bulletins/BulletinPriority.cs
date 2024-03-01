using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class BulletinPriority : ValueObject
    {
        public Guid Id { get; set; }
        public Priority Priority {  get; set; }

        public BulletinPriority() { }
        private BulletinPriority(string strPriority)
        {
            DwellerValidation(new StringIsNotNull(strPriority));
            var priority = ConvertPriorityFromUIValue(strPriority);
            Priority = priority;
        }

        public static class BulletinPriorityFactory
        {
            public static BulletinPriority CreateNewPriority(string strPriority)
           {
                return new BulletinPriority(strPriority);
            }
        }

        internal void ConvertPriorityFromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Priority), dbValue))
            {
                Priority = (Priority)dbValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }
        internal static Priority ConvertPriorityFromUIValue(string uiValue)
        {
            if (int.TryParse(uiValue, out int parsedvalue) && Enum.IsDefined(typeof(Priority), parsedvalue))
            {
                return (Priority)parsedvalue;
            }
            throw new ArgumentException("Invalid value for priority");
        }
    }
}
