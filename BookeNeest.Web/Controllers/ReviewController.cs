using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Models;
using Microsoft.AspNet.Identity;
using Unity.Attributes;

namespace BookeNeest.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IBookService bookService;

        [InjectionConstructor]
        public ReviewController(IReviewService reviewService, IBookService bookService)
        {
            this.reviewService = reviewService;
            this.bookService = bookService;
        }
        // GET Review/
        public ActionResult Index()
        {
            var reviewDtos = reviewService.GetRecentReviews(25);

            var recents = Mapper.Map<IList<ReviewViewModel>>(reviewDtos);

            return View("Index", recents);
        }

        [HttpGet]
        public ActionResult Details(string reviewId)
        {
            var reviewDto = reviewService.FindById(Guid.Parse(reviewId));

            var review = Mapper.Map<ReviewViewModel>(reviewDto);

            return View("Details", review);
        }

        [HttpGet]
        [Authorize]
        public ActionResult PostReview(string bookId)
        {
            var bookDto = bookService.FindById(Guid.Parse(bookId));

            var model = new ReviewViewModel
            {
                BookName = bookDto.Name,
                BookId = bookId,
                UserId = User.Identity.GetUserId(),
            };

            return View("PostReview", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Critic, Reader")]
        [ValidateAntiForgeryToken]
        public ActionResult PostReview(ReviewViewModel model)
        {
            // TODO: Post Review Service
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model Validation Errors", "Model Validation Error");
                return View("PostReview", model);
            }

            var reviewDto = Mapper.Map<ReviewDto>(model);

            var id = reviewService.AddNew(reviewDto);

            return RedirectToAction("Index");
        }

        
    }
}