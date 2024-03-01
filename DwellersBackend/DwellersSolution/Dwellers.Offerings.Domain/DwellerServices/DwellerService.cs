using Dwellers.Offerings.Domain.ValueObjects;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.Offerings.Domain.DwellerServices
{
    public sealed class DwellerService : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ServiceScope { get; private set; }
        public bool ServiceStatus { get; private set; }

        public ICollection<ProvidedService> ProvidedServices { get; set; }

        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public DwellerService() { }

        public DwellerService(string name, string desc)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }

        public async Task<DwellerResponse<bool>> SetServiceScope(string scope)
        {
            DwellerResponse<bool> response = new();
            if (Enum.TryParse(scope, out VisibilityScope serviceScope))
            {
                ServiceScope = serviceScope;
                return await response.SuccessResponse();
            }

            return await response.ErrorResponse("Scope could not be parsed to enum.");
        }
    }
}

