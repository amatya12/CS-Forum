using CsForum.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsForum.Models.Post
{
    public class PostListingModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public ForumViewModel Forum { get; set; }

        public int RepliesCount { get; set; }

    }
}
