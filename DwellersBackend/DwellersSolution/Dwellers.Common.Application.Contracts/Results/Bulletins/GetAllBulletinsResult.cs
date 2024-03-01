using Dwellers.Common.Application.Contracts.Results.Bulletins.DTOs;

namespace Dwellers.Common.Application.Contracts.Results.Bulletins
{
    public record GetAllBulletinsResult(
        List<BulletinListDto> ListOfAllBulletins);
}
