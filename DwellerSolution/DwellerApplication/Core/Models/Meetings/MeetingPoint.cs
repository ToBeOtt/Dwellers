using DwellerApplication.Core.Models.User;

namespace DwellerApplication.Core.Models.Meetings
{
    public class MeetingPoint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHandled { get; set; }
       
        //Navigational properties
        public Meeting Meeting { get; set; }
        public AppUser AppUser { get; set; }
    }
}
