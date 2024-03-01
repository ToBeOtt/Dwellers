using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class BulletinTag : ValueObject
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public Guid BulletinId { get; set; }
        public Bulletin Bulletin { get; set; }


        public BulletinTag() { }
        internal BulletinTag CreateNewTag(string newTag, Bulletin bulletin)
        {
             return new BulletinTag(newTag, bulletin);
        }
        private BulletinTag(string newTag, Bulletin bulletin)
        {
            Tag = newTag;
            Bulletin = bulletin;
        }

        public static class BulletinTagFactory
        {
            public static List<BulletinTag> CreateNewCollectionOfTags
                (List<string> newTags, Bulletin bulletin)
            {
                List<BulletinTag> newListOfTags = new();
                foreach (var tag in newTags)
                {
                    tag.ToUpper();
                    newListOfTags.Add(new BulletinTag(tag, bulletin));
                }
                DwellerValidation(new NoDuplicateTagsMayExist(newListOfTags, null));
                return newListOfTags;
            }
        }

        internal async Task<DwellerResponse<bool>> AddTagToCollection
            (List<BulletinTag> currentTags, string newTag, Bulletin bulletin)
        {
            DwellerResponse<bool> response = new();
            DwellerValidation(new NoDuplicateTagsMayExist(currentTags, newTag));

            var outcome = DwellerValidation(new DomainIsBroken(currentTags, newTag));
            if(!outcome.IsSuccess)
                return await response.ErrorResponse(outcome.ErrorMessage);

            CreateNewTag(newTag, bulletin);
            return await response.SuccessResponse();
        }
    }
}
