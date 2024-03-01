using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellings
{
    public sealed class Dwelling : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InvitationCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte[]? DwellingProfilePhoto { get; set; }
        public List<DwellingGallery>? DwellingGallery { get; set; } = new List<DwellingGallery>();

        public DwellingInhabitant DwellingInhabitant { get; set; }

        public bool IsArchived { get; set; } 
        public DateTime IsCreated { get; set; }
        public DateTime IsModified { get; set; }
        public Dwelling() { }
        private Dwelling(string? name, string? description)
        {
            Id = Guid.NewGuid();
            
            Name = name;
            Description = description;

            IsCreated = DateTime.Now;
            IsArchived = false;
            InvitationCode = Guid.NewGuid();
        }

        public static class DwellingFactory
        {
            public static async Task<Dwelling> Create(
                    string name, string? description)
            {
                var dwelling = new Dwelling(name, description);
                return dwelling;
            }
        }
        
        internal async Task AddProfilePhoto(IFormFile file)
        {
            DwellingProfilePhoto = await ConvertIFormFileToByteArray(file);
        }

        internal async Task<byte[]> ConvertIFormFileToByteArray(IFormFile file)
        {
            DwellerResponse<bool> response = new();

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] imageData = memoryStream.ToArray();
            return imageData;
        }
        
        internal async Task<DwellingGallery> AddImageToGallery(IFormFile image, Dwelling dwelling)
        {
            var imageToByteArray = await ConvertIFormFileToByteArray(image);
            var dwellingGallery = new DwellingGallery(imageToByteArray, dwelling);
            return dwellingGallery;
        }
    }
}
