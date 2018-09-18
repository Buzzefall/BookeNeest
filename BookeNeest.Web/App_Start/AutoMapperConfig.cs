using System;
using System.Linq;
using AutoMapper;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using BookeNeest.Domain.Models.Identity;
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
                config.CreateMap<CreateBookViewModel, BookDto>(MemberList.None)
                    
                    .ForMember(dto => dto.Authors, opt => opt.MapFrom(model =>
                            model.Authors
                            .Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(author => new AuthorDto
                                {
                                    Id = Guid.NewGuid(),
                                    Name = author,
                                    BirthDate = new DateTime(2000, 1, 1)
                                }).ToList()))

                    .ForMember(dto => dto.Genres, opt => opt.MapFrom(model =>
                            model.Genres
                            .Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(genre => new GenreDto
                                {
                                    Id = Guid.NewGuid(),
                                    Name = genre
                                }).ToList()));

                //    .ConstructUsing(b => new BookDto
                //{
                //    Authors = b.Authors.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries)
                //        .Select(author => new AuthorDto { Name = author }).ToList(),

                //    Genres = b.Genres.Split(new[] {',', '.'}, StringSplitOptions.RemoveEmptyEntries)
                //        .Select(genre => new GenreDto { Name = genre}).ToList(),

                //    Name = b.Name,
                //    Description = b.Description,
                //    PublicationDate = b.PublicationDate
                //});

                config.CreateMap<CreateUserViewModel, UserDto>(MemberList.None);
                config.CreateMap<CreateAuthorViewModel, AuthorDto>(MemberList.None);


                config.CreateMap<AuthorDto, AuthorViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);

                config.CreateMap<GenreDto, GenreViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);

                config.CreateMap<TagDto, TagViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);

                config.CreateMap<ReviewDto, ReviewViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);


                config.CreateMap<BookDto, BookViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);


                config.CreateMap<UserDto, UserViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);

                config.CreateMap<User, UserViewModel>(MemberList.None)
                    .ReverseMap().ValidateMemberList(MemberList.None);
            });

            IsConfigured = true;
        }
    }
}