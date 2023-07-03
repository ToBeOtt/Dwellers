using DwellerApplication.Core.Models.User;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DwellerApplication.Core.Models
{
    public class HouseUser
    {
        public int Id { get; set; }
        public House House { get; set; }

        public AppUser AppUser { get; set; }
    }
}
