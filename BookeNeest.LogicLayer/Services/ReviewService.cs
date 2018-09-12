using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookeNeest.Data.DB;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public class ReviewService : ServiceBase, IReviewService
    {
        [InjectionConstructor]
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Guid AddNew(ReviewDto reviewDto)
        {
            var review = Mapper.Map<Review>(reviewDto);

            review.Id = Guid.NewGuid();

            unitOfWork.ReviewRepository.Add(review);
            unitOfWork.CommitAsync().Wait();

            return review.Id;
        }

        public ReviewDto FindById(Guid id)
        {
            var review = unitOfWork.ReviewRepository.FindById(id);

            return Mapper.Map<ReviewDto>(review);
        }

        public IList<ReviewDto> FindByName(string name)
        {
            var review = unitOfWork.ReviewRepository.FindByName(name);

            return Mapper.Map<IList<ReviewDto>>(review);
        }

        public IList<ReviewDto> GetRecentReviews(int amount)
        {
            var reviews = unitOfWork.ReviewRepository.GetRecent(amount);

            return Mapper.Map<IList<ReviewDto>>(reviews);
        }

    }
}