namespace Dwellers.Common.Application.Contracts.Results.DwellerEvents
{
    public class GetEventResult(Guid id, string eventTitle, string eventText, 
        DateTime eventDate, string eventScope)
    {
        public string Id { get; set; } = id.ToString();
        public string EventTitle { get; set; } = eventTitle;
        public string EventText { get; set; } = eventText;
        public string EventDate { get; set; } = eventDate.ToShortDateString();
        public string EventScope { get; set; } = eventScope;
    }

}
