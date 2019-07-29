using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsForum.Data;
using CsForum.Data.Models;
using CsForum.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CsForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        public ProfileController(UserManager<ApplicationUser> userManager, 
                                IApplicationUser userService,
                                IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;

        }
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel
            {
                UserId = id,
                UserName = user.UserName,
                Email = user.Email,
                MemberSince = user.MemberSince,
                UserRating = user.Rating.ToString(),
                ProfileImageUrl = user.ProfileImageUrl,
                IsAdmin = userRoles.Contains("Admin")

            };

            return View();
        }
    }
}