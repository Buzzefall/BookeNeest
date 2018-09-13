using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.DTOs
{
    public class ReviewDto : EntityBaseDto<Guid>
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Text { get; set; }
        public int? Rating { get; set; }
    }
}