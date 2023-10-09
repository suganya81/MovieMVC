using MovieMVC.Areas.Identity.Data;

namespace MovieMVC.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public string ReleaseDate { get; set;}

        public string? ImagePost {  get; set;}

        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }

        public string UserId { get; set; }
        public MovieMVCUser User { get; set; }
       
    }
}
