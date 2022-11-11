using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.CQRS;
using Peadetfoods.Domain.Entities;

namespace Peadetfoods.Infrastructure.CQRS.Queries
{
    public class GetProductQuery : IQuery<Product>
    {
        public long ProductId { get; set; }
    }

    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var product = await _unitOfWork.Products.FindAsync(request.ProductId);
            return product;
        }
    }
}
