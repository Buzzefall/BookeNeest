using BookeNeest.Domain;
using BookeNeest.Domain.Contracts.Services;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;

        [InjectionConstructor]
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
