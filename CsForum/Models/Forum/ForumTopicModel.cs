using CsForum.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsForum.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumViewModel Forum { get; set; }

        public IEnumerable<PostListingModel> Posts { get; set; }

        public string SearchQuery { get; set; }
    }
}
