using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peadetfoods.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity<long>
    {
        public Product()
        {
            Images = new HashSet<ProductImage>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
