using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IRepository<Product> productRepository;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return Guid.Empty;
            }

            await productRepository.RemoveAsync(product);
            return product.Id;
        }
    }
}
