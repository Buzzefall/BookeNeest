using System.ComponentModel.DataAnnotations;

namespace BookeNest.Domain.Models
{
    public class EntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
