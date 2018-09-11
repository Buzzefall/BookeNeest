using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookeNeest.Web.Areas.Admin.Controllers.Base;
using BookeNeest.Web.Areas.Admin.Models;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class AuthorController : AdminAreaControllerBase
    {
        // GET: Admin/Author
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Author/Create
        public ActionResult Create()
        {
            return View("CreateAuthor");
        }

        // POST: Admin/Author/Create
        [HttpPost]
        public ActionResult Create(AuthorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            

            return RedirectToAction("Recents", "Book");
        }

        //// GET: Admin/Author/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Author/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Admin/Author/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Author/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}