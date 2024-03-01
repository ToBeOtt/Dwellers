namespace Dwellers.Common.Application.Contracts.Commands.Bulletins
{

    public record AddBulletinCommand(
           string DwellerId,
           string Title,
           string Text,
           List<string> BulletinTags,
           string BulletinStatus,
           string BulletinPriority,
           string Visibility,
           List<Guid> ChosenDwellings);

}
