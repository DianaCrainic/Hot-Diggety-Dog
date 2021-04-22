using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Product> productRepository;

        public CreateProductCommandHandler(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Category = request.Category
            };

            await productRepository.CreateAsync(product);
            return product.Id;
        }
    }
}
