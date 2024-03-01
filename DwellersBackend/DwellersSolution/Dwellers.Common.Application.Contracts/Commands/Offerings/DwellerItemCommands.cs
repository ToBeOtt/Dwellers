using Microsoft.AspNetCore.Http;

namespace Dwellers.Common.Application.Contracts.Commands.Offerings
{
    public record AddDwellerItemCommand(
           string Name,
           string Desc,
           string ItemScope,
           IFormFile ItemPhoto,
           Guid DwellingId
           );

    public record RemoveDwellerItemCommand(
          Guid ItemId
          );

}
