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

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class UserController : AdminAreaControllerBase
    {
        // TODO: CRUD(User) operations, etc.

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