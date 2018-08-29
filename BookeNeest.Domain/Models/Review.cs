using BookeNeest.Domain.Identity;
using System;

namespace BookeNeest.Domain.Models
{
    public class Review : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Text { get; set; }
        public int? Rating { get; set; }


        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}