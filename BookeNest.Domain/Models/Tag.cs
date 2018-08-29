﻿using System;
using System.Collections.Generic;

namespace BookeNest.Domain.Models
{
    public class Tag : EntityBase<Guid>
    {
        public string Text { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
