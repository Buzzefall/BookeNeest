using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;
using AutoMapper;

using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Web.Models;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        [InjectionConstructor]
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Book
        public ActionResult Recents()
        {
            // TODO: Autommaper dto -> view model - DONE
            
            // Dto
            var books = bookService.GetRecentBooks(7);
            var model = Mapper.Map<IList<BookViewModel>>(books);
            
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(string bookName)
        {
            // TODO: Use services here?
            //var container = new Unity.UnityContainer();
            //var bookService = ;
            var book = bookService.FindByName(bookName);

            var model = Mapper.Map<BookViewModel>(book);

            return View(model);
        }

        // GET: Book/Create
        public ActionResult Add()
        {
            return View("AddNewBook");
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Recents");
            }
            catch
            {
                return View("Recents");
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Recents");
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Recents");
            }
            catch
            {
                return View("Recents");
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Recents");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Recents");
            }
            catch
            {
                return View("Recents");
            }
        }
    }
}
