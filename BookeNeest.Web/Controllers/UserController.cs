using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BookeNeest.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BookeNeest.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private BookeNeestUserManager _userManager;
        public BookeNeestUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<BookeNeestUserManager>();
            private set => _userManager = value;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var users = UserManager.Users.Take(20).ToList();

            var model = Mapper.Map<IList<UserViewModel>>(users);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string userId)
        {
            var user = UserManager.FindById(Guid.Parse(userId));

            var model = Mapper.Map<UserViewModel>(user);

            return View(model);
        }
    }
}