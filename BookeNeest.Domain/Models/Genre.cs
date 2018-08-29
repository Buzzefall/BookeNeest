using System;
using System.Collections.Generic;

namespace BookeNeest.Domain.Models
{
    public class Genre : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}