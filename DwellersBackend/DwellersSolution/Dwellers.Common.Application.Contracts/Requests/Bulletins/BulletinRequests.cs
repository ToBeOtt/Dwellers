namespace Dwellers.Common.Application.Contracts.Requests.Bulletins
{
    public class BulletinRequests
    {
        public record AddBulletinRequest(
          string Title,
          string Text,
          List<string> BulletinTags,
          string BulletinStatus,
          string BulletinPriority,
          string Visibility,
          List<Guid>? ChosenDwellings
          );

    }
}

