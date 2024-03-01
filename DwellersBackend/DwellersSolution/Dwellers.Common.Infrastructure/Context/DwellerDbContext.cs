using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Interfaces;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellersEvents.Domain.Entites;
using Dwellers.DwellersEvents.Domain.Entites.ValueObjects;
using Dwellers.Offerings.Domain.DwellerItems;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Infrastructure.Context
{
    public class DwellerDbContext : DbContext, IDbSetRepository
    {
        public DwellerDbContext(DbContextOptions<DwellerDbContext> options)
            : base(options)
        {
        }

        // DwellerCore
        public DbSet<Dweller> Dwellers { get; set; }
        public DbSet<Dwelling> Dwellings { get; set; }
        public DbSet<DwellingInhabitant> DwellingInhabitants { get; set; }

        // Chats
        public DbSet<DwellerConversation> DwellerConversations { get; set; }
        public DbSet<MemberInConversation> MemberInConversations { get; set; }
        public DbSet<DwellerMessage> DwellerMessages { get; set; }

        // Events
        public DbSet<DwellerEvent> DwellerEvents { get; set; }
        public DbSet<DwellerScope> DwellerScopes { get; set; }

        // Bulletins
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<BulletinPriority> BulletinPriorities { get; set; }
        public DbSet<BulletinScope> BulletinScopes { get; set; }
        public DbSet<BulletinStatus> BulletinStatus { get; set; }
        public DbSet<BulletinTag> BulletinTags { get; set; }
        public DbSet<ScopedDwelling> ScopedDwellings { get; set; }

        // Offerings
        public DbSet<DwellerItem> DwellerItems { get; set; }
        public DbSet<BorrowedItem> BorrowedItems { get; set; }
        public DbSet<DwellerService> DwellerServices { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
          => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
