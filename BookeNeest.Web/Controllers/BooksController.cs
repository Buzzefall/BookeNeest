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

        // GET: Books
        public ActionResult Recents()
        {
            // TODO: Autommaper dto -> view model - DONE
            
            // Dto
            var books = bookService.GetRecentBooks(7);
            var model = Mapper.Map<IList<BookViewModel>>(books);
            
            return View(model);
        }

        // GET: Books/Details/5
        public ActionResult Details(string bookName)
        {
            // TODO: Use services here?
            //var container = new Unity.UnityContainer();
            //var bookService = ;
            var book = bookService.FindByName(bookName);

            var model = Mapper.Map<BookViewModel>(book);

            return View(model);
        }
    }
}
