using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsForum.Models.Forum
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumViewModel> ForumList { get; set; }

    }
}
