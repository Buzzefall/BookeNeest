using System;
using System.Collections.Generic;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.Domain.Models
{
    public class Book : EntityBase<Guid>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int? PagesTotal { get; set; }
        public int? Rating { get; set; }
        
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
