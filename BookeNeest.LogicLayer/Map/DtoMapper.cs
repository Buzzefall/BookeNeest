using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.LogicLayer.Map
{
    public static class DtoMapper
    {

        public static bool IsConfigured { get; private set; } = false;

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookDto>();
                cfg.CreateMap<User, UserDto>();
            });

            IsConfigured = true;
        }
    }
}