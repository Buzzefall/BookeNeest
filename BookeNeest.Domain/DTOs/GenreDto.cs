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

        public GenreDto(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public override string ToString() => Name;
    }
}
