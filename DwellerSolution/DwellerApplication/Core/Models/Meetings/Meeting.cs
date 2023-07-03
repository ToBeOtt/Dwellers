using DwellerApplication.Core.Models.User;
using DwellerApplicationApplication.Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellerApplication.Core.Models.Meetings
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MeetingDate { get; set; }
        public bool IsOver { get; set; }

        //Navigational properties
        public ICollection<MeetingPoint> MeetingPoints { get; set; }
        public House House { get; set; }
        public AppUser AppUser { get; set; }
    }
}
