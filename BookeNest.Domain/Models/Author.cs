using System;
using System.Collections.Generic;

namespace BookeNest.Domain.Models
{
    public class Author : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string About { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}