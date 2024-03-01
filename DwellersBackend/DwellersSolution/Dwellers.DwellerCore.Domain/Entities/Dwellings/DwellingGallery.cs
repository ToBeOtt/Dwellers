using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellings
{
    public class DwellingGallery : ValueObject
    {
        public Guid Id { get; set; }
        public byte[] DwellingImage { get; set; }

        public Guid DwellingId { get; set; }
        public Dwelling? Dwelling { get; set; }


        public DwellingGallery() { }
        internal DwellingGallery(byte[] image, Dwelling dwelling)
        {
            Id = Guid.NewGuid();
            DwellingImage = image;
            Dwelling = dwelling;
        }
    }
}
