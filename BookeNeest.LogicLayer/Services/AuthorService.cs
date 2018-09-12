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
    public class AuthorService : ServiceBase, IAuthorService
    {
        [InjectionConstructor]
        public AuthorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Guid AddNew(AuthorDto authorDto)
        {
            var author = Mapper.Map<Author>(authorDto);

            author.Id = Guid.NewGuid();

            unitOfWork.AuthorRepository.Add(author);
            unitOfWork.CommitAsync();

            return author.Id;
        }

        public IList<AuthorDto> FindByName(string name)
        {
            var authors = unitOfWork.AuthorRepository.FindByName(name);

            return Mapper.Map<List<AuthorDto>>(authors);
        }

        public AuthorDto FindById(Guid id)
        {
            var book = unitOfWork.AuthorRepository.FindById(id);

            return Mapper.Map<AuthorDto>(book);
        }

        public IList<AuthorDto> TakeAuthorsOrdered(int amount)
        {
            var authors = unitOfWork.AuthorRepository.GetRecent(amount);
            var authorsDto = Mapper.Map<IList<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}