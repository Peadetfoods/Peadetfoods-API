using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.CQRS;
using Peadetfoods.Domain.Entities;
using Peadetfoods.Infrastructure.Common;

namespace Peadetfoods.Infrastructure.CQRS.Queries
{
    public class GetProductsQuery : IQuery<PagedList<Product>>
    {
    }

    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedList<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PagedList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.Products.Items;

            return products.PaginateAsync(1, products.Count());
        }
    }
}
