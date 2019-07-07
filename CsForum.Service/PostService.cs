using CsForum.Data;
using CsForum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsForum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                            .Include(p => p.Forum)
                            .Include(p=>p.Replies)
                            .Include(a => a.User);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                         .Include(post => post.User)
                         .Include(post => post.Forum)
                         .Include(post => post.Replies)
                            .ThenInclude(post=>post.User)
                         .First();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            var posts = forum.Posts;
            return String.IsNullOrEmpty(searchQuery)
                ?
                posts
                :
                posts.Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetLatestPosts(int numberOfPosts)
        {
            return GetAll().OrderByDescending(p => p.Created).Take(numberOfPosts);
        }

        public IEnumerable<Post> GetPostsByForums(int id)
        {
            var posts = _context.Forums.Where(Forum => Forum.Id == id).First().Posts;

            return posts;
            
           
        }
    }
}
