using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using AutoMapper;
using BookeNeest.Domain.Constants;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models.Identity;
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
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            // TODO: Add creation of user, then redirect..
            if (!ModelState.IsValid) return View("CreateUser", model);

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = model.UserName
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = await UserManager.AddToRoleAsync(user.Id, BookeNeestUserRoles.Reader);

                if (result.Succeeded)
                {
                    return RedirectToAction("Create");
                }

            }

            else

            {
                ModelState.AddModelError("AccountService error", "Failed to create user.");
                return View("CreateUser", model);
            }

            return RedirectToAction("Create");
        }
    }
}