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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("auth_schema"); 
        }

        public DbSet<DbUser> Users { get; set; } = null!;
    }
}
