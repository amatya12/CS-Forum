using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsForum.Data;
using CsForum.Data.Models;
using CsForum.Models.Forum;
using CsForum.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace CsForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }


        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                  .Select(forum => new ForumViewModel
                  {
                      Id = forum.Id,
                      Title = forum.Title,
                      Description = forum.Description

                  });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {

            var forum = _forumService.GetById(id);
            var posts = new List<Post>();

            posts = _postService.GetFilteredPosts(forum, searchQuery).ToList();
            //  var posts = _postService.GetPostsByForums(id);
            var postListings = posts.Select(post => new PostListingModel
            {
                ID = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                Author = post.User.UserName,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)

            });
            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new {id, searchQuery });
        }
        private ForumViewModel BuildForumListing(Post post)
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

        private ForumViewModel BuildForumListing(Forum forum)
        {

            return new ForumViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl

            };
        }


    }
}
