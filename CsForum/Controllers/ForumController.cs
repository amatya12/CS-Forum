using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsForum.Data;
using CsForum.Data.Models;
using CsForum.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace CsForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
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

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);

           
        }

    }
}