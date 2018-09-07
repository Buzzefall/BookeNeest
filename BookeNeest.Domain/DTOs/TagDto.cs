using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.DTOs
{
    public class TagDto : EntityBaseDto<Guid>
    {
        public string Text { get; set; }
        public string Category { get; set; }

        public TagDto(string text)
        {
            Text = text;
        }

        public override string ToString() => Text;
    }
}
