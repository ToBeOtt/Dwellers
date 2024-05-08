using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Infrastructure.Context;
using Dwellers.DwellerCore.Domain.Entities;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Dwellers.DwellersEvents.Domain.Entites;
using Dwellers.Offerings.Domain.DwellerItems;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Common.Infrastructure.Development
{
    public static class DwellerInMemorySeeds
    {
        public static async Task Initialize(IServiceProvider serviceProvider, List<string> idsFromAuthSeed)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<DwellerDbContext>();
                context.Database.EnsureCreated();

                // Check if the database has been seeded
                if (!context.Dwellers.Any())
                {
                    // BASIC DWELLER AND DWELLING SEED - FIRST DWELLING
                    var dweller = new Dweller
                    {
                        Id = idsFromAuthSeed[0],
                        Email = "test@mail.com",
                        Alias = "Zane Radstorm",
                        IsCreated = DateTime.UtcNow,
                        IsArchived = false
                    };
                    context.Dwellers.Add(dweller);

                    var dwelling = new Dwelling
                    {
                        Id = new Guid("4f47a3f5-8d3f-4b2b-98a0-5f8306c8b9a4"),
                        Name = "Fort Phoenix",
                        Description = "Fort Phoenix stands as a bastion of hope amidst the desolation, a reclaimed military outpost turned community stronghold. Its towering walls, adorned with salvaged steel and vibrant graffiti, shelter a resilient group of survivors. Here, amidst the echoes of the old world, they forge a new future, defiant against the wasteland's chaos.",
                        IsCreated = DateTime.UtcNow,
                        IsArchived = false,
                        InvitationCode = Guid.NewGuid()
                    };
                    context.Dwellings.Add(dwelling);


                    var dwellingInhabitant = new DwellingInhabitant
                    {
                        Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                        Dwelling = dwelling,
                        Dweller = dweller
                    };
                    context.DwellingInhabitants.Add(dwellingInhabitant);

                    // SEED CONVERSATION FOR DWELLING
                    var dwellerConversation = new DwellerConversation("Torpavägen 14 (home)");
                    //var membersOfConversation = DwellerConversation.AddNewConversationMembers(dwelling, dwellerConversation);
                    var membersOfConversation = new MemberInConversation(dwelling, dwellerConversation);

                    context.DwellerConversations.Add(dwellerConversation);
                    context.MemberInConversations.Add(membersOfConversation);



                    // SEED BULLETINS
                    var bulletin = Bulletin.BulletinPostFactory.CreateNewBulletin(dweller, "New Droid Arrival: A Game-Changer for Our Community",
                        "Exciting news for our community!Next Monday, we're welcoming the latest addition to our tech arsenal - a state-of-the-art droid. Engineered to enhance our daily lives, this droid promises to revolutionize chores, security, and even companionship in our homes. Its arrival marks a significant leap towards a more efficient, safe, and connected future. Stay tuned for the unveiling!",
                        ["Happy"],
                        "1", "1", [dwelling], "1");

                    context.BulletinPriorities.Add(bulletin.Priority);
                    context.BulletinStatus.Add(bulletin.Status);
                    foreach (var tag in bulletin.Tags)
                    {
                        context.BulletinTags.Add(tag);
                    }
                    context.BulletinScopes.Add(bulletin.Scope);
                    context.Bulletins.Add(bulletin);

                    var bulletin1 = Bulletin.BulletinPostFactory.CreateNewBulletin(dweller,
                        "Victory Over the Neighbors: Game Night Triumph",
                        "Last night's game against our neighbors wasn't just a win; it was a testament to our community's spirit and strategy. Our victory in the wasteland's most anticipated card game showdown brought us not only bragging rights but also closer as a team. The laughter and cheers echoing through our shelter were reminders of the strength and unity we share. Here's to many more wins!",
                        ["Content"],
                        "0", "2", [dwelling], "0");

                    context.BulletinPriorities.Add(bulletin1.Priority);
                    context.BulletinStatus.Add(bulletin1.Status);
                    foreach (var tag in bulletin1.Tags)
                    {
                        context.BulletinTags.Add(tag);
                    }
                    context.BulletinScopes.Add(bulletin1.Scope);
                    context.Bulletins.Add(bulletin1);

                    await context.SaveChangesAsync();

                    var bulletin2 = Bulletin.BulletinPostFactory.CreateNewBulletin(dweller,
                        "\r\nEncounter with the Unknown: A Cautionary Tale",
                        "Last night, our peaceful evening was interrupted by a mysterious stranger. Cloaked in shadows, their intentions unclear, they wandered close to our perimeter. While no harm came to us, their presence serves as a stark reminder: not all who roam the wasteland have our best interests at heart. Stay vigilant, communicate suspicious activities, and let's protect our sanctuary together.",
                        ["Sad", "Scared"],
                        "0", "2", [dwelling], "0");

                    context.BulletinPriorities.Add(bulletin2.Priority);
                    context.BulletinStatus.Add(bulletin2.Status);
                    foreach (var tag in bulletin2.Tags)
                    {
                        context.BulletinTags.Add(tag);
                    }
                    context.BulletinScopes.Add(bulletin2.Scope);
                    context.Bulletins.Add(bulletin2);

                    // SEED EVENTS
                    var dwellerEvent = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent("Vault-Tec's Wasteland BBQ Bash!",
                    "Amid the ruins of the Capital Wasteland, we're hosting a dinner that promises refuge and a taste of the old world's charm. Vault dwellers and wanderers alike, join us by the flickering firelight for an evening of hearty meals, shared stories, and the warmth of newfound companionship. Your RSVP on your Pip-Boy secures your seat at this table of unity.",
                    dwelling, dweller, "1");
                    dwellerEvent.EventDate = DateTime.UtcNow.AddDays(-4).ToUniversalTime();

                    context.DwellerScopes.Add(dwellerEvent.EventScope);
                    context.DwellerEvents.Add(dwellerEvent);

                    var dwellerEvent1 = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent("Power Plant Restoration Call",
                         "In the heart of the Wasteland, a beacon of hope flickers. The old power plant, silent for years, stands ready for revival. Join us, engineers and dreamers, as we breathe life back into its steel veins. Together, we can light up the darkness, turning the tide of survival into one of thriving. Gear up and meet by dawn; your skills can forge our future.",
                         dwelling, dweller, "1");
                    dwellerEvent.EventDate = DateTime.UtcNow.AddDays(-6).ToUniversalTime();

                    context.DwellerScopes.Add(dwellerEvent1.EventScope);
                    context.DwellerEvents.Add(dwellerEvent1);

                    var dwellerEvent2 = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent("Megaton Aftermath: Cleanup Initiative",
                         "The dust settles on Megaton's remains, marking a call to arms for all survivors. As we stand in the shadow of devastation, our resolve must be stronger than the rubble underfoot. Join us in reclaiming hope from chaos, clearing debris, and salvaging the future, piece by piece. Together, we rebuild not just a place, but a community.",
                         dwelling, dweller, "0");
                    dwellerEvent.EventDate = DateTime.UtcNow.AddDays(-9).ToUniversalTime();

                    context.DwellerScopes.Add(dwellerEvent2.EventScope);
                    context.DwellerEvents.Add(dwellerEvent2);

                    // DWELLER ITEMS
                    var dwellerItem = new DwellerItem("Yxa", "Nyslipad", dwelling, "Neightbourhood");
                    var borrowedItemStatus = new BorrowedItem(dwelling, dwellerItem);

                    context.DwellerItems.Add(dwellerItem);
                    context.BorrowedItems.Add(borrowedItemStatus);


                    var dwellerItem1 = new DwellerItem("Motorsåg",
                        "Klingan är lite slö.", dwelling, "Dwelling");
                    var borrowedItemStatus1 = new BorrowedItem(dwelling, dwellerItem1);

                    context.DwellerItems.Add(dwellerItem1);
                    context.BorrowedItems.Add(borrowedItemStatus1);

                    var dwellerItem2 = new DwellerItem("Ciderpress", "14L. Gammal som gatan.", dwelling, "Dwelling")
                    {
                        IsBorrowed = true
                    };
                    var borrowedItemStatus2 = new BorrowedItem(dwelling, dwellerItem2);

                    context.DwellerItems.Add(dwellerItem2);
                    context.BorrowedItems.Add(borrowedItemStatus2);


                    await context.SaveChangesAsync();






                    // SECOND DWELLING
                    var dweller2 = new Dweller
                    {
                        Id = idsFromAuthSeed[1],
                        Email = "varg@mail.com",
                        Alias = "Gustava Linné",
                        IsCreated = DateTime.UtcNow,
                        IsArchived = false
                    };
                    context.Dwellers.Add(dweller2);


                    var dwelling2 = new Dwelling
                    {
                        Id = new Guid("5f47a3f5-5d3f-4b2b-98a0-5f8306c8b9a4"),
                        Name = "Belfragegatan 10",
                        Description = "Gult trähus från 1935.",
                        IsCreated = DateTime.UtcNow,
                        IsArchived = false,
                        InvitationCode = Guid.NewGuid()
                    };
                    context.Dwellings.Add(dwelling2);


                    var dwellingInhabitant2 = new DwellingInhabitant
                    {
                        Id = new Guid("7c9e3479-7425-40de-944b-e07fc1f90ae7"),
                        Dwelling = dwelling2,
                        Dweller = dweller2
                    };
                    context.DwellingInhabitants.Add(dwellingInhabitant2);

                    // SEED CONVERSATION FOR DWELLING
                    var dwellerConversation2 = new DwellerConversation("Belfragegatan 10 (home)");
                    //var membersOfConversation = DwellerConversation.AddNewConversationMembers(dwelling, dwellerConversation);
                    var membersOfConversation2 = new MemberInConversation(dwelling2, dwellerConversation2);

                    context.DwellerConversations.Add(dwellerConversation2);
                    context.MemberInConversations.Add(membersOfConversation2);


                    // SEED BULLETINS
                    var bulletin4 = Bulletin.BulletinPostFactory.CreateNewBulletin(dweller2, "Altan-fix",
                        "Vi ska fixa med altanen. Vi skulle uppskatta hjälp.. :D",
                        ["Happy"],
                        "1", "1", [dwelling2], "1");

                    context.BulletinPriorities.Add(bulletin4.Priority);
                    context.BulletinStatus.Add(bulletin4.Status);
                    foreach (var tag in bulletin4.Tags)
                    {
                        context.BulletinTags.Add(tag);
                    }
                    context.BulletinScopes.Add(bulletin4.Scope);
                    context.Bulletins.Add(bulletin4);

                    var bulletin5 = Bulletin.BulletinPostFactory.CreateNewBulletin(dweller2,
                        "This is a bulletin",
                        "This is just a random bulletin with no content, intent for testing only.",
                        ["Content"],
                        "0", "2", [dwelling2], "0");

                    context.BulletinPriorities.Add(bulletin5.Priority);
                    context.BulletinStatus.Add(bulletin5.Status);
                    foreach (var tag in bulletin5.Tags)
                    {
                        context.BulletinTags.Add(tag);
                    }
                    context.BulletinScopes.Add(bulletin5.Scope);
                    context.Bulletins.Add(bulletin5);

                    await context.SaveChangesAsync();

                    // SEED EVENTS
                    var dwellerEvent4 = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent("Barbeque-night",
                    "Barbeque tomorrow at nince",
                    dwelling2, dweller2, "1");
                    dwellerEvent4.EventDate = DateTime.UtcNow.AddDays(-4).ToUniversalTime();

                    context.DwellerScopes.Add(dwellerEvent4.EventScope);
                    context.DwellerEvents.Add(dwellerEvent4);

                    var dwellerEvent5 = DwellerEvent.DwellerEventFactory.CreateNewDwellerEvent("Clean sidewalks",
                         "This will be a cleaning event for the entire neightbourhood, come please.",
                         dwelling2, dweller2, "1");
                    dwellerEvent5.EventDate = DateTime.UtcNow.AddDays(-6).ToUniversalTime();

                    context.DwellerScopes.Add(dwellerEvent5.EventScope);
                    context.DwellerEvents.Add(dwellerEvent5);

                    // DWELLER ITEMS
                    var dwellerItem4 = new DwellerItem("Spade", "Platt", dwelling2, "Neightbourhood");
                    var borrowedItemStatus4 = new BorrowedItem(dwelling2, dwellerItem4);

                    context.DwellerItems.Add(dwellerItem4);
                    context.BorrowedItems.Add(borrowedItemStatus4);


                    var dwellerItem5 = new DwellerItem("Digitalt piano",
                        "Ostämt.", dwelling2, "Dwelling");
                    var borrowedItemStatus5 = new BorrowedItem(dwelling2, dwellerItem5);

                    context.DwellerItems.Add(dwellerItem5);
                    context.BorrowedItems.Add(borrowedItemStatus5);


                    // ESTABLISH A CONNECTION
                    dwelling.DwellingFriends.Add(dwelling2.Id);
                    dwelling2.DwellingFriends.Add(dwelling.Id);

                    await context.SaveChangesAsync();

                }
            }
        }
    }
}

