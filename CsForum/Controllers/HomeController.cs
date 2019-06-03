using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsForum.Models;
using CsForum.Models.Home;
using CsForum.Data;
using CsForum.Models.Post;
using CsForum.Data.Models;
using CsForum.Models.Forum;

namespace CsForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        public HomeController(IPost post , IForum forum)
        {
            _postService = post;
            _forumService = forum;
        }
        public IActionResult Index()
        {

            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(post => new PostListingModel
              
            {
                ID = post.Id,
                Author = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                Title = post.Title,
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListingForPost(post)

            });
            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = ""  

            };

        }

        private ForumViewModel BuildForumListingForPost(Post post)
        {
            var forum = post.Forum;
            return new ForumViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
