using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Peadetfoods.Domain.Entities;
using Peadetfoods.Infrastructure.Common;
using Peadetfoods.Infrastructure.Dtos;

namespace Peadetfoods.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            CreateMap<Product, ProductDto>();
        }
    }
}
