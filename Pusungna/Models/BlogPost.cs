using System;

namespace Pusungna.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public string? Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}

