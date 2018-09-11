using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookeNeest.Web.Areas.Admin.Controllers.Base;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class ManageController : AdminAreaControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}