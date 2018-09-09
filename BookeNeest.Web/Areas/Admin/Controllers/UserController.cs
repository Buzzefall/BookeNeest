using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
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
        public ActionResult Create(CreateUserViewModel model)
        {
            // TODO: Add creation of user, then redirect..



            return RedirectToAction("Create");
        }
    }
}