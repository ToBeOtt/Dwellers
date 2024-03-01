using SharedKernel.Domain;

namespace Dwellers.Bulletins.Domain.Bulletins.Rules
{
    public class DomainIsBroken : IBusinessRule
    {
        private readonly string? _newTag;
        private readonly List<BulletinTag> _tags;

        public DomainIsBroken(List<BulletinTag> tags, string? newTag)
        {
            _tags = tags;
            _newTag = newTag;
        }

        public bool IsBroken()
        {
            if (_newTag != null)
            {
                var strNewTag = _newTag.ToUpper();
                return ! _tags.Select(tag => tag.ToString().ToUpper()).Any(strTag => strTag == strNewTag);
            }

            return ! _tags.Select(tag => tag.ToString().ToUpper()).GroupBy(strTag => strTag)
                       .Any(g => g.Count() > 1);
        }

        public string Message => "There can not be two identical tags";
    }
}
