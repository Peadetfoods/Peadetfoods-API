using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.Repository;
using Peadetfoods.Domain.Entities;
using Peadetfoods.Infrastructure.Common.Database;
using Peadetfoods.Infrastructure.Repositories;

namespace Peadetfoods.Infrastructure.Common
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            Products = new BaseRepo<Product>(context);
            ProductCategories = new BaseRepo<ProductCategory>(context);
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IBaseRepo<Product> Products { get; }
        public IBaseRepo<ProductCategory> ProductCategories { get; }
    }
}
