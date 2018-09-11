using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.DTOs;

namespace BookeNeest.LogicLayer.Services
{
    public class GenreService : ServiceBase<GenreDto>
    {
        public GenreService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}