using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.DTOs
{
    public class GenreDto : EntityBaseDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString() => Name;
    }
}
