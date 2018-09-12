using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using Unity.Attributes;
using Unity.Injection;

namespace BookeNeest.LogicLayer.Services
{
    public class GenreService : ServiceBase, IGenreService
    {
        [InjectionConstructor]
        public GenreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Guid AddNew(GenreDto genreDto)
        {
            var genre = Mapper.Map<Genre>(genreDto);

            genre.Id = Guid.NewGuid();

            unitOfWork.GenreRepository.Add(genre);
            unitOfWork.CommitAsync();

            return genre.Id;
        }

        public GenreDto FindById(Guid id)
        {
            var genre = unitOfWork.GenreRepository.FindById(id);

            return Mapper.Map<GenreDto>(genre);
        }

        public IList<GenreDto> FindByName(string name)
        {
            var genre = unitOfWork.GenreRepository.FindByName(name);

            return Mapper.Map<IList<GenreDto>>(genre);
        }

        public IList<GenreDto> GetRecentGenres(int amount)
        {
            var genres = unitOfWork.GenreRepository.GetRecent(amount);

            return Mapper.Map<IList<GenreDto>>(genres);
    }
}