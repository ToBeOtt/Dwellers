using DwellerApplication.Core.Models.HousePosts;
using DwellerApplication.Core.Models.Meetings;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DwellerApplication.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<HouseUser> HouseUsers => Set<HouseUser>();
        public DbSet<House> Houses => Set<House>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Reply> Replies => Set<Reply>();
        public DbSet<Meeting> Meetings => Set<Meeting>();
        public DbSet<MeetingPoint> MeetingPoints => Set<MeetingPoint>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Modify delete-cascading behaviour
            builder.Entity<Reply>()
                    .HasOne(r => r.Post)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(r => r.Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MeetingPoint>()
                    .HasOne(mp => mp.Meeting)
                    .WithMany(m => m.MeetingPoints)
                    .HasForeignKey(mp => mp.Id)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}