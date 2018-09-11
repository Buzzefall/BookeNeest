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

                config.CreateMap<AddBookViewModel, BookDto>(MemberList.None);

                config.CreateMap<BookDto, BookViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);

                config.CreateMap<AuthorDto, AuthorCreateViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);


                config.CreateMap<CreateUserViewModel, UserDto>(MemberList.None);

                config.CreateMap<UserDto, UserViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);
            });

            IsConfigured = true;
        }
    }
}