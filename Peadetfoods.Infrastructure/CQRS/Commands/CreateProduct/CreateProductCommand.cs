using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.CQRS;
using Peadetfoods.Domain.Entities;

namespace Peadetfoods.Infrastructure.CQRS.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description
            };

            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();

            return product;
        }
    }
}
