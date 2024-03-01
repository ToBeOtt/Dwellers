using SharedKernel.Domain;

namespace Dwellers.DwellersEvents.Domain.Entites.ValueObjects
{
    public enum Visibility
    {
        Household,
        Neightbourhood,
        All
    }

    public class DwellerScope : ValueObject
    {
        public Guid Id { get; set; }
        public Visibility Scope { get; private set; }

        public DwellerScope() { }
        private DwellerScope(string scope)
        {
            var visibility = ConvertScopeFromUIValue(scope);
            Scope = visibility;
        }
        public static class VisibilityFactory
        {
            public static DwellerScope CreateNewVisibilityScope(string strVisibility)
            {
                return new DwellerScope(strVisibility);
            }
        }

        internal static Visibility ConvertScopeFromUIValue(string uiValue)
        {
            if (int.TryParse(uiValue, out int parsedvalue) && Enum.IsDefined(typeof(Visibility), parsedvalue))
                return (Visibility)parsedvalue;
            
            else
                throw new ArgumentException("Invalid value for visibility");;
        }
        internal static Visibility FromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Visibility), dbValue))
                return (Visibility)dbValue;
       
            else
                throw new ArgumentException("Invalid value for status");
        }
    }
}
