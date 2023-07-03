using Microsoft.AspNetCore.Identity;

namespace DwellerApplication.Core.Models.User
{
    public class HouseMember : IdentityRole
    {
        public HouseMember() : base("HouseMember")
        {
        }
    }
}
