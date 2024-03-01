using SharedKernel.Domain;

namespace Dwellers.Offerings.Domain.ValueObjects
{
    public enum VisibilityScope
    {
        Dwelling,
        Neightbourhood,
        All
    }

    public class Visibility : ValueObject
    {
        public Guid Id { get; set; }
        public VisibilityScope Scope { get; }
        public Visibility() { }

        public Visibility(VisibilityScope scope)
        {
            Scope = scope;
        }

        public static Visibility FromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(VisibilityScope), dbValue))
            {
                return new Visibility((VisibilityScope)dbValue);
            }
            throw new ArgumentException("Invalid value for VisibilityScope");
        }
    }
}
