using BookeNeest.Domain.Models;

using System.Data.Entity.ModelConfiguration;

namespace BookeNeest.Data.DB.Maps
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();
            
            // Many to many relations : explicitly give x.Genres and x.Books navigation properties as arguments
            HasMany(x => x.Genres).WithMany(x => x.Books).Map(x =>
            {
                x.ToTable("BookGenres");
                x.MapLeftKey("BookId");
                x.MapRightKey("GenreId");
            });

            HasMany(x => x.Authors).WithMany(x => x.Books).Map(x =>
            {
                x.ToTable("BookAuthors");
                x.MapLeftKey("BookId");
                x.MapRightKey("AuthorId");
            });
            
            HasMany(x => x.Tags).WithMany(x => x.Books).Map(x =>
            {
                x.ToTable("BookTags");
                x.MapLeftKey("BookId");
                x.MapRightKey("TagId");
            });

            HasMany(x => x.Reviews).WithRequired(x => x.Book);
        }
    }
}
