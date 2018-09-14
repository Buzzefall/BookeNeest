using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Areas.Admin.Controllers.Base;
using BookeNeest.Web.Areas.Admin.Models;
using Unity.Attributes;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class AuthorController : AdminAreaControllerBase
    {
        private readonly IAuthorService authorService;

        [InjectionConstructor]
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(string authorId)
        {
            var authorDto = authorService.FindById(Guid.Parse(authorId));


            return View("Details");
        }

        // GET: Admin/Author/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateAuthor");
        }

        // POST: Admin/Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model Validation Errors", "Model validation error.");
                return View("CreateAuthor", model);
            }

            var authorDto = Mapper.Map<AuthorDto>(model);

            authorService.AddNew(authorDto);

            return RedirectToAction("Recents", "Book");
        }



        // GET: Admin/Author
        //public ActionResult Recents()
        //{
        //    return View();
        //}

        //// GET: Admin/Author/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}




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