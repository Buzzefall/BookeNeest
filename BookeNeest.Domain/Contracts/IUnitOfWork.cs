using System.Threading.Tasks;
using BookeNeest.Domain.Contracts.Repositories;

namespace BookeNeest.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ITagRepository TagRepository { get; }

        void Commit();
        Task CommitAsync();
        void Discard();
    }
}
