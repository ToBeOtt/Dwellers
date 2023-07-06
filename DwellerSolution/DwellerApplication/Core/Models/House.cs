using DwellerApplication.Core.Models.User;
using DwellerApplicationApplication.Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellerApplication.Core.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string InvitationCode { get; set; }

        // Navigation properties
        public ICollection<HouseUser> HouseUsers { get; set; }
    }
}
