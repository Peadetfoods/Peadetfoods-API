using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peadetfoods.Application.Repository;
using Peadetfoods.Domain.Entities;

namespace Peadetfoods.Application.Common
{
    public interface IUnitOfWork
    {
        IBaseRepo<Product> Products { get; }
        IBaseRepo<ProductCategory> ProductCategories { get; }

        Task SaveAsync();
    }
}
