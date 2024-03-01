namespace Dwellers.Common.Application.Contracts.Results.DwellerEvents.DTOs
{
    public class ListEventDto(Guid id, string eventTitle, string eventText, string eventDate)
    {
        public string Id { get; set; } = id.ToString();
        public string EventTitle { get; set; } = eventTitle;
        public string EventText { get; set; } = eventText;
        public string EventDate { get; set; } = eventDate;
    }
}
