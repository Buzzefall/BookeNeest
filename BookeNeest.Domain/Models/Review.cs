using System;
using BookeNeest.Domain.Models.Identity;

namespace BookeNeest.Domain.Models
{
    public class Review : EntityBase<Guid>
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Text { get; set; }
        public int? Rating { get; set; }


        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}