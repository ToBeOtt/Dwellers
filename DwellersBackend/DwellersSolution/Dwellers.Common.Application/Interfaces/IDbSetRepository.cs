using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Chat.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellersEvents.Domain.Entites;
using Dwellers.DwellersEvents.Domain.Entites.ValueObjects;
using Dwellers.Offerings.Domain.DwellerItems;
using Dwellers.Offerings.Domain.DwellerServices;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Common.Application.Interfaces
{
    public interface IDbSetRepository
    {
        // DwellerCore
        DbSet<Dweller> Dwellers { get; set; }
        DbSet<Dwelling> Dwellings { get; set; }
        DbSet<DwellingInhabitant> DwellingInhabitants { get; set; }

        // Chat
        DbSet<DwellerConversation> DwellerConversations { get; set; }
        DbSet<MemberInConversation> MemberInConversations { get; set; }
        DbSet<DwellerMessage> DwellerMessages { get; set; }

        // Events
        DbSet<DwellerEvent> DwellerEvents { get; set; }
        DbSet<DwellerScope> DwellerScopes { get; set; }

        // Bulletins
        DbSet<Bulletin> Bulletins { get; set; }
        DbSet<BulletinPriority> BulletinPriorities { get; set; }
        DbSet<BulletinScope> BulletinScopes { get; set; }
        DbSet<BulletinStatus> BulletinStatus { get; set; }
        DbSet<BulletinTag> BulletinTags { get; set; }
        DbSet<ScopedDwelling> ScopedDwellings { get; set; }

        // Offerings
        DbSet<DwellerItem> DwellerItems { get; set; }
        DbSet<BorrowedItem> BorrowedItems { get; set; }

        DbSet<DwellerService> DwellerServices { get; set; }
        DbSet<ProvidedService> ProvidedServices { get; set; }
    }
}
