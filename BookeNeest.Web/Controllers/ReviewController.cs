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

        [InjectionConstructor]
        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        // GET Review/
        public ActionResult Index()
        {
            var reviewDtos = reviewService.GetRecentReviews(5);

            var recents = Mapper.Map<IList<ReviewViewModel>>(reviewDtos);

            return View("Index", recents);
        }

        [HttpGet]
        [Authorize]
        public ActionResult PostReview(string bookId)
        {
            var model = new ReviewViewModel
            {
                BookId = Guid.Parse(bookId),
                UserId = Guid.Parse(User.Identity.GetUserId()),
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