using CsForum.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsForum.Models.Search
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }

        

    }
}
