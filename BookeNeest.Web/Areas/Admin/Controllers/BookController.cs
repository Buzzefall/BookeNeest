using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;
using AutoMapper;
using BookeNeest.Data.DB;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Areas.Admin.Controllers.Base;
using BookeNeest.Web.Models;

namespace BookeNeest.Web.Areas.Admin.Controllers
{
    public class BookController : AdminAreaControllerBase
    {
        private readonly IBookService bookService;

        [InjectionConstructor]
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Book/Details/5
        public ActionResult Details(string bookName)
        {
            // TODO: Use services here?
            //var container = new Unity.UnityContainer();
            //var bookService = ;
            var book = bookService.FindByName(bookName);

            var model = Mapper.Map<IList<BookViewModel>>(book);

            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View("CreateBook");
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddBookViewModel book)
        {
            // TODO: Add correct mapping
            List<string> authors =
                new List<string>(book.Authors.Split(new[] {',', ' ', '.'}, StringSplitOptions.RemoveEmptyEntries));

            List<string> genres =
                new List<string>(book.Genres.Split(new[] {',', ' ', '.'}, StringSplitOptions.RemoveEmptyEntries));

            var bookVM = new BookViewModel
            {
                Id = Guid.NewGuid().ToString(),
                ISBN = Guid.NewGuid().ToString(),
                PublicationDate = DateTime.Today.ToLongTimeString(),
                Authors = authors,
                Genres = genres,
                Name = book.Name
            };

            var bookDto = Mapper.Map<BookDto>(bookVM);

            bookService.AddNew(bookDto);

            return RedirectToAction("Recents", "Book", new {area = ""});
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Recents", "Book", new {area = ""});
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Recents", "Book", new {area = ""});
            }
            catch
            {
                return RedirectToAction("Recents", "Book", new {area = ""});
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Recents", "Book", new {area = ""});
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Recents", "Book", new {area = ""});
            }
            catch
            {
                return RedirectToAction("Recents", "Book", new {area = ""});
            }
        }
    }
}