namespace Dwellers.Common.Application.Contracts.Results.Offerings.DTOs
{
    public class DwellerItemDto(Guid id, string name, string description, 
        bool isAvailable, int itemScope, byte[]? itemPhoto)
    {
        public string Id { get; set; } = id.ToString();
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public bool IsAvailable { get; set; } = isAvailable;
        public int ItemScope {  get; set; } = itemScope;
        public byte[]? ItemPhoto { get; set; } = itemPhoto;

    }
}
