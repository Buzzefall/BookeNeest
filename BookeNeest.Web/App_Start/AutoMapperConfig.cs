using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Web.Areas.Admin.Models;
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
                // config.AllowNullCollections = true;
                config.CreateMap<BookDto, BookViewModel>(MemberList.None).ReverseMap();
                config.CreateMap<AuthorDto, AuthorCreateViewModel>(MemberList.None).ReverseMap();
                config.CreateMap<UserDto, UserViewModel>(MemberList.None).ReverseMap();
            });

            IsConfigured = true;
        }
    }
}