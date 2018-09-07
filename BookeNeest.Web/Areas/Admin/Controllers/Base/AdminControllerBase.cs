using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.Web.Areas.Admin.Controllers.Base
{
    [Authorize(Roles = "Admin")]
    public class AdminAreaControllerBase : Controller
    {

    }
}