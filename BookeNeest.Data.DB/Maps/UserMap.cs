using System.Data.Entity.ModelConfiguration;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.Data.DB.Maps
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.UserName)
                .IsRequired();
            
            HasMany(user => user.Books).WithMany(book => book.Users).Map(x =>
            {
                x.ToTable("BookUsers");
                x.MapLeftKey("UserId");
                x.MapRightKey("BookId");
            });

            //HasMany(user => user.Reviews).WithRequired(review => review.User);
        }
    }
}
