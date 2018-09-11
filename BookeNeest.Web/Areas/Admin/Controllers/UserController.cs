using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using AutoMapper;
using BookeNeest.Web.Areas.Admin.Controllers.Base;
using BookeNeest.Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity.Owin;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    // TODO: CRUD(User) operations, etc.
    public class UserController : AdminAreaControllerBase
    {
        private BookeNeestUserManager _userManager;

        public BookeNeestUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<BookeNeestUserManager>();
            private set => _userManager = value;
        }



        public ActionResult Create()
        {
            return View("CreateUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel userModel)
        {
            // TODO: Add creation of user, then redirect..
            if (!ModelState.IsValid) return View("CreateUser", userModel);

            var user = Mapper.Map<Domain.Models.Identity.User>(userModel);

            user.Id = Guid.NewGuid();
            user.About = "New user";

            var result = await UserManager.CreateAsync(user);

            if (result.Succeeded)
            {
                UserManager.Addt
            }

            else

            {
                ModelState.AddModelError("AccountService error", "Failed to create user.");
                return View("CreateUser", userModel);
            }


            return RedirectToAction("Create");
        }
    }
}