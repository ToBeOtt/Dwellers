using DwellerApplication.Core.Models.User;
using DwellerApplicationApplication.Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace DwellerApplication.Core.Models.HousePosts
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        //Navigational properties
        public AppUser AppUser { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
