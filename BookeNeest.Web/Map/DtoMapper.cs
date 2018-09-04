using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Models;

namespace BookeNeest.Web.Map
{
    public static class DtoMapper
    {

        public static bool IsConfigured { get; private set; } = false;

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookDto, BookViewModel>();
                cfg.CreateMap<UserDto, UserViewModel>();
                
            });

            IsConfigured = true;
        }
    }
}