using System.ComponentModel.DataAnnotations;

namespace UserLinkService.Models
{
    public class UserLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortenLink { get; set; }
    }
}
