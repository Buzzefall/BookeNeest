using System.ComponentModel.DataAnnotations;

namespace BookeNeest.Domain.Models
{
    public class EntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public EntityBase()
        {
            
        }
    }
}
