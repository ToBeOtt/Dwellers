using DwellerApplication.Core.Models.HousePosts;
using DwellerApplication.Core.Models.Meetings;
using Microsoft.AspNetCore.Identity;

namespace DwellerApplication.Core.Models.User
{
    public class AppUser : IdentityUser
    {
        //Navigational properties
        public ICollection<HouseUser> HouseUsers { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
