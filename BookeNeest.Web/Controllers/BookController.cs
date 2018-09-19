using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Attributes;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.Models;
using BookeNeest.LogicLayer.Services;
using BookeNeest.Web.Models;
using Microsoft.Ajax.Utilities;

namespace BookeNeest.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IImageService imageService;

        [InjectionConstructor]
        public BookController(IBookService bookService, IImageService imageService)
        {
            this.bookService = bookService;
            this.imageService = imageService;
        }

        // GET: Books
        public ActionResult Recents()
        {
            // TODO: Autommaper dto -> view model - DONE

            // Dto
            var books = bookService.GetBooksRecent(15);


            var model = Mapper.Map<IList<BookViewModel>>(books);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recents(BookFilterViewModel filterViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model Validation Errors", "Model Validation Error");
                return PartialView("_BookFilterPartial");
            }

            // TODO: rework (currently no diff from GET Books/Recents)

            //Map filter
            var filter = Mapper.Map<BookFilter>(filterViewModel);

            //Achieve bookDtos
            var booksDtos = bookService.GetBooksFiltered(filter);

            //Map dtos to model
            var model = Mapper.Map<IList<BookViewModel>>(booksDtos);

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

        public FilePathResult ImageFor(string bookId)
        {
            var virtualPath = imageService.GetImageFilePath(Guid.Parse(bookId));

            var actualPath = Server.MapPath(virtualPath);

            var image = File(Server.MapPath("~Content/Images/Books/no-image.jpg"), "image/jpeg")
                        ??
                        File("~Content/Images/Books/no-image.jpg", "image/jpeg");

            return image;
        }
    }
}