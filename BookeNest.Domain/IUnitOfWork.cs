using BookeNest.Domain.Contracts.Repositories;

namespace BookeNest.Domain
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ITagRepository TagRepository { get; }

        void Commit();
        void Discard();
    }
}
