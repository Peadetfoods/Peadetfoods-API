using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peadetfoods.Domain.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeaturedImage { get; set; }
    }
}
