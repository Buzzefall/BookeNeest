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
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        [InjectionConstructor]
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Books
        public ActionResult Recents()
        {
            // TODO: Autommaper dto -> view model - DONE
            
            // Dto
            var books = bookService.GetRecentBooks(10);

            var model = Mapper.Map<IList<BookViewModel>>(books);
            
            return View(model);
        }

        // GET: Books/Details/5
        public ActionResult Details(string bookId)
        {
            // TODO: Use services here?
            //var container = new Unity.UnityContainer();
            //var bookService = ;
            var book = bookService.FindById(Guid.Parse(bookId));

            var model = Mapper.Map<BookViewModel>(book);

            return View(model);
        }
    }
}
