using CsForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsForum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id , string newContent);
        Task AddReply(PostReply reply);
        IEnumerable<Post> GetPostsByForums(int id);
        IEnumerable<Post> GetLatestPosts(int numberOfPosts);
    }
}
