using Microsoft.AspNetCore.Http;

namespace Dwellers.Common.Application.Contracts.Commands.Dwellers
{
    public record SetDwellerProfilePhotoCommand(
          string DwellerId,
          IFormFile DwellerPhoto);
}
