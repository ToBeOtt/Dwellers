using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellers
{
    public sealed class Dweller : BaseEntity
    {
        public string? Id { get; set; } 
        public string? Alias { get; set; }
        public string? Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public bool? IsArchived { get; set; }
        public DateTime? IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public DwellingInhabitant DwellingInhabitant { get; set; }

        public Dweller() { }
        private Dweller(string id, string alias, string email)
        {
            Id = id;

            Alias = alias;
            Email = email;
            IsCreated = DateTime.Now;
            IsArchived = false;
        }
        public static class DwellerFactory
        {
            public static async Task<Dweller> Create(
                    string id, string alias, string email)
            {
                var dwelling = new Dweller(id, alias, email);
                return dwelling;
            }
        }

        public async Task<bool> SetProfilePhoto(IFormFile file)
        {

            ProfilePhoto = await ConvertIFormFileToByteArray(file);
            if (ProfilePhoto.IsNullOrEmpty())
                return false;

            else
                return true;
        }
        internal static async Task<byte[]> ConvertIFormFileToByteArray(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] imageData = memoryStream.ToArray();
            return imageData;
        }
    }
}
