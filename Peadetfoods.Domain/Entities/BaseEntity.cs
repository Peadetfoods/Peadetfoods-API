using System.ComponentModel.DataAnnotations;

namespace Peadetfoods.Domain.Entities
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
