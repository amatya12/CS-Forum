using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsForum.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CsForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _userService;
        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}