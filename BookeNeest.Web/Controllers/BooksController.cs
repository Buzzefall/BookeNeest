using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Attributes;

using BookeNeest.Domain.Contracts.Services;
using BookeNeest.LogicLayer.Services;
using BookeNeest.Web.Models;

namespace BookeNeest.Web.Controllers
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
        public ActionResult Index()
        {
            var container = new UnityContainer();
            
            //bookService = (IBookService) container.Resolve(typeof(IBookService), "BookService");

            // Dto
            var books = bookService.GetRecentBooks(15);

            // TODO: Autommaper dto -> view model

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
        public ActionResult AddNewBook()
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Index");
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Index");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
