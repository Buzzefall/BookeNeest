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
using BookeNeest.Web.Models;
using Unity.Attributes;
using Unity.Injection;

namespace BookeNeest.Web.Controllers
{
    public class ReviewController : AdminAreaControllerBase
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
        [Authorize(Roles = "Admin, Critic")]
        public ActionResult PostReview()
        {
            return View("PostReview");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Critic")]
        [ValidateAntiForgeryToken]
        public ActionResult PostReview(ReviewViewModel model)
        {
            // TODO: Post Review Service

            var reviewDto = Mapper.Map<ReviewDto>(model);

            var id = reviewService.AddNew(reviewDto);

            return View("Details");
        }

        
    }
}