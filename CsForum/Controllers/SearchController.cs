using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsForum.Data;
using CsForum.Data.Models;
using CsForum.Models.Forum;
using CsForum.Models.Post;
using CsForum.Models.Search;
using Microsoft.AspNetCore.Mvc;

namespace CsForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListing = posts.Select(post => new PostListingModel
            {
                ID = post.Id,
                Author = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)

            });

            var model = new SearchResultModel
            {
                posts = postListing,
                SearchQuery = searchQuery,
                EmptySearchResults =areNoResults
            };

            return View(model);


        }
        private ForumViewModel BuildForumListing(Post post)
        {
            return new ForumViewModel
            {
                Id = post.Forum.Id,
                Title = post.Forum.Title,
                Description = post.Forum.Description,
                ImageUrl = post.Forum.ImageUrl
            };
        }
    

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}