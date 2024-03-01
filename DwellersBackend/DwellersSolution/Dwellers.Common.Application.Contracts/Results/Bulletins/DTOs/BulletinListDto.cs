namespace Dwellers.Common.Application.Contracts.Results.Bulletins.DTOs
{
    public class BulletinListDto(string? bulletinTitle,string? author, string? bulletinText, 
        string? bulletinScope, string? datePublished, string? dateModified)
    {
        public string? BulletinTitle { get; set; } = bulletinTitle;
        public string? Author { get; set; } = author;
        public string? BulletinText { get; set; } = bulletinText;
        public string? BulletinScope { get; set; } = bulletinScope;

        public string? DatePublished { get; set; } = datePublished;
        public string? DateModified { get; set; } = dateModified;
    }
}
