using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Peadetfoods.Infrastructure.CQRS.Commands.AddProductImage
{
    public class AddProductImageRequest
    {
        public IFormFile Image { get; set; }
    }
}
