using System;

namespace Pusungna.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
