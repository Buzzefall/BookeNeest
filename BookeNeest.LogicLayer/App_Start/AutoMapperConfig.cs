﻿using System.Collections.Generic;
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
            config.CreateMap<Author, AuthorDto>(MemberList.None)
                .ReverseMap().ValidateMemberList(MemberList.None);
            
            config.CreateMap<string, AuthorDto>(MemberList.None).ConstructUsing(name => new AuthorDto(name));

            config.CreateMap<Genre, GenreDto>(MemberList.None)
                .ReverseMap().ValidateMemberList(MemberList.None);

            config.CreateMap<string, GenreDto>(MemberList.None).ConstructUsing(name => new GenreDto(name));

            config.CreateMap<Review, ReviewDto>(MemberList.None)
                .ReverseMap().ValidateMemberList(MemberList.None);



            config.CreateMap<Book, BookDto>(MemberList.None)
                .ReverseMap().ValidateMemberList(MemberList.None);



            config.CreateMap<User, UserDto>(MemberList.None)
                .ReverseMap().ValidateMemberList(MemberList.None);

            IsConfigured = true;
        }
    }
}