using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Visibility
    {
        Custom,
        Household,
        Neighbourhood,
        Global
    }

    public class BulletinScope : BaseEntity
    {
        public Guid Id { get; set; }
        public Visibility Visibility { get; set; }

        public Guid BulletinId { get; set; }
        public Bulletin Bulletin { get; set; }

        public List<ScopedDwelling> DwellingsInScope { get; set; } = [];

        public BulletinScope() { }
        internal BulletinScope(List<Dwelling> listOfDwellings, Bulletin bulletin, string visibility)
        {
            Id = Guid.NewGuid();
            Bulletin = bulletin;

            foreach(var dwelling in listOfDwellings)
            {
                DwellingsInScope.Add(new ScopedDwelling(bulletin, dwelling));
            }
            Visibility = Visibility.Custom;
            // Raise event for selected dwellings that a bulletin has been posted

            if ((DwellingsInScope.Count <= 0 || DwellingsInScope == null) && visibility !=  null)
            {
                ConvertVisibilityFromUIValue(visibility);
            }      
        }

        public static class BulletinScopeFactory
        {
            public static BulletinScope SetBulletinScope(
                    List<Dwelling> listOfDwellings,
                    Bulletin bulletin,
                    string visibility
                    )
            {
                return new BulletinScope(listOfDwellings, bulletin, visibility);
            }
        }

        public void ConvertVisibilityFromUIValue(string visibilityValue)
        {
            int parsedValue = Convert.ToInt32(visibilityValue);

            if (Enum.IsDefined(typeof(Visibility), parsedValue))
            {
                Visibility = (Visibility)parsedValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }
    }
}
