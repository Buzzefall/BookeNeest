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

            var model = new CreateUserViewModel
            {
                Name = "",
                Email = "",
                Password = "",
                //Roles = BookeNeestUserRoles.ToSelectList()
            };

            //(ViewBag.RoleSelectList as SelectList).

            return View("CreateUser", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            // TODO: Add creation of user, then redirect..
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model Validation Errors", "Model Validation Error");

                return View("CreateUser", model);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = model.Email,
                Email = model.Email
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = await UserManager.AddToRolesAsync(user.Id, model.SelectedRoles
                    //.Where(role => role.Selected)
                    //.Select(role => role.Text)
                    .ToArray());

                if (result.Succeeded)
                {
                    return RedirectToAction("Create");
                }
            }

            else

            {
                ModelState.AddModelError("AccountService error", String.Join(", ", result.Errors));
                return View("CreateUser", model);
            }

            return RedirectToAction("Create");
        }
    }
}