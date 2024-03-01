using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.Offerings.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Domain.DwellerItems
{
    public sealed class DwellerItem : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; private set; }
        public bool IsBorrowed { get; set; }
        
        public Dwelling OwnerOfItem { get; private set; }
        public ICollection<BorrowedItem> BorrowedItems { get; set; }

        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public DwellerItem() { }
        public DwellerItem(string name, string desc, Dwelling owner, string scope)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            OwnerOfItem = owner;
            IsBorrowed = false;
            SetItemScope(scope);   

            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }
        public void SetItemScope(string scope)
        {
            DwellerResponse<bool> response = new();
            if (Enum.TryParse(scope, out VisibilityScope itemscope))
                ItemScope = itemscope;
        }

        public async Task<DwellerResponse<bool>> SetItemPhoto(IFormFile photo)
        {
            DwellerResponse<bool> response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    ItemPhoto = imageData;
                    return await response.SuccessResponse();
                }
            }
            catch (Exception ex)
            {
                return await response.ErrorResponse(ex.Message);
            }
        }
    }
}
