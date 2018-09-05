using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Models;

namespace BookeNeest.Web
{
    public static class AutoMapperConfig
    {
        public static bool IsConfigured { get; private set; } = false;

        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                // DAL Models to DTOs
                LogicLayer.AutoMapperConfig.Configure(config);

                // DTOs to View Models
                config.CreateMap<BookDto, BookViewModel>();
                config.CreateMap<UserDto, UserViewModel>();
            });

            IsConfigured = true;
        }
    }
}