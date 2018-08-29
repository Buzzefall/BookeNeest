using BookeNeest.Domain.Models;

using System.Data.Entity.ModelConfiguration;

namespace BookeNeest.Data.DB.Maps
{
    public class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Text)
                .IsRequired();
            
            //HasRequired(review => review.User).WithMany();
            //HasRequired(review => review.Book).WithMany();
            HasRequired(review => review.User).WithMany(user => user.Reviews);
            HasRequired(review => review.Book).WithMany(book => book.Reviews);


        }
    }
}
