using Microsoft.AspNetCore.Identity;

namespace DwellerApplicationApplication.Core.Models.User
{
    public class HouseOwner : IdentityRole
    {
        public HouseOwner() : base("HouseOwner")
        {
        }
    }
}

