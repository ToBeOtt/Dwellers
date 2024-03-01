namespace Dwellers.Common.Application.Contracts.Results.Chats.DTOs
{
    public class DwellerMessageDto(Guid id, string message, DateTime messageDate, string? author, bool isRead)
    {
        public Guid Id { get; set; } = id;
        public string Message { get; set; } = message;
        public string MessageDate { get; set; } = messageDate.ToShortDateString();
        public string? Author { get; set; } = author;
        public bool IsRead { get; set; } = isRead;

    }
}
