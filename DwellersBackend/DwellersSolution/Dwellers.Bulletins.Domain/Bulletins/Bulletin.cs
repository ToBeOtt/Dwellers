using Dwellers.Bulletins.Domain.Bulletins.Rules;
using Dwellers.DwellerCore.Domain.Entities.Dwellers;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using SharedKernel.Domain;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinPriority;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinScope;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinStatus;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinTag;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class Bulletin : BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }

        public List<BulletinTag> Tags { get; set; }
        public BulletinStatus Status { get; set; }
        public BulletinPriority Priority { get; set; }
        public BulletinScope Scope { get; set; }

        public Dweller Dweller { get; set; }

        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime IsModified { get; set; }

        public Bulletin() { }

        private Bulletin(
            Dweller dweller,
            string title,
            string text,
            List<string> tags,
            string bulletinPriority,
            string bulletinStatus,
            List<Dwelling> listOfDwellings,
            string visibility
            )
        {
            Id = Guid.NewGuid();
            Dweller = dweller;
            Title = title;
            Text = text;
            Priority = BulletinPriorityFactory.CreateNewPriority(bulletinPriority);
            Status = BulletinStatusFactory.CreateNewStatus(bulletinStatus);
            Tags = BulletinTagFactory.CreateNewCollectionOfTags(tags, this);
            Scope = BulletinScopeFactory.SetBulletinScope(listOfDwellings, this, visibility);
            IsArchived = false;
            IsCreated = DateTime.UtcNow;
        }
        public static class BulletinPostFactory
        {
           public static Bulletin CreateNewBulletin(
                Dweller dweller,
                string title,
                string text,
                List<string> tags,
                string bulletinPriority,
                string bulletinStatus,
                List<Dwelling> liftOfDwellings,
                string visibility)
            {
                return new Bulletin(
                    dweller,
                    title,
                    text,
                    tags,
                    bulletinPriority,
                    bulletinStatus,
                    liftOfDwellings,
                    visibility);
            }
        }

        public void StatusUpdateToDone(/*BulletinStatusChangedToDoneDomainEvent @event*/)
        {
            IsArchived = true;
        }

        public void ArchiveBulletin(Bulletin bulletin)
        {
            IsArchived = true;
            IsModified = DateTime.UtcNow;
        }

        public void AddTags(List<BulletinTag> tags)
        {
            foreach(var tag in tags) 
            {
                DwellerValidation(new InputNotNullOrEmpty<BulletinTag>(tag));
                Tags.Add(tag);
            }
        }
    }
}
