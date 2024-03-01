using Dwellers.Authentication.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Authentication.Infrastructure.Data
{
    public class AuthDbContext : IdentityDbContext<DbUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<DbUser> Users { get; set; } = null!;
    }
}
