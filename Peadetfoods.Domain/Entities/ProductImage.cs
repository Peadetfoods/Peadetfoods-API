using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Peadetfoods.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage : BaseEntity<long>
    {
        public long ProductId { get; set; }
        public string File { get; set; }
    }
}
