using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Http;

using Peadetfoods.Application.Common;
using Peadetfoods.Application.CQRS;
using Peadetfoods.Domain.Entities;
using Peadetfoods.Domain.Exceptions;

namespace Peadetfoods.Infrastructure.CQRS.Commands.AddProductImage
{
    public class AddProductImageCommand : ICommand
    {
        public long ProductId { get; set; }
        public IFormFile Image { get; set; }
    }

    public class AddProductImageCommandHandler : ICommandHandler<AddProductImageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.FindAsync(request.ProductId);

            if (product is null)
            {
                ProductNotFoundException.Throw(request.ProductId);
            }

            // process file

            product!.Images.Add(new ProductImage
            {
                File = "google.com"
            });

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
