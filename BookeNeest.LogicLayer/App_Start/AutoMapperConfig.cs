using System.Collections.Generic;
using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.LogicLayer
{
    public static class AutoMapperConfig
    {
        public static bool IsConfigured { get; private set; } = false;

        // Called from BookeNest.Web at application start
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Author, AuthorDto>();
            
            config.CreateMap<Genre, GenreDto>();
            config.CreateMap<Review, ReviewDto>();
            config.CreateMap<User, UserDto>();

            IsConfigured = true;
        }
    }
}