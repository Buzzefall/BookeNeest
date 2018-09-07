using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.DTOs
{
    public class AuthorDto : EntityBaseDto<Guid>
    {
        public string Name { get; set; }
        public string About { get; set; }

        public AuthorDto(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override string ToString() => Name;
    }
}
