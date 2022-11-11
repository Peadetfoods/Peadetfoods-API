using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peadetfoods.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }

        public static void Throw(long id)
        {
            throw new ProductNotFoundException($"Product not found with ID (${id})");
        }
    }
}
