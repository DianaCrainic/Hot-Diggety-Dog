using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductRequestFeatures.Commands
{
    public class CreateProductsRequestCommandHandler : IRequestHandler<CreateProductsRequestCommand, Guid>
    {
        private readonly IRepository<ProductsRequest> productsRequestRepository;

        public CreateProductsRequestCommandHandler(IRepository<ProductsRequest> productsRequestRepository, IInventoryProductsRepository inventoryProductsRepository)
        {
            this.productsRequestRepository = productsRequestRepository;
        }

        public async Task<Guid> Handle(CreateProductsRequestCommand request, CancellationToken cancellationToken)
        {
            ProductsRequest productsRequest = new()
            {
                ProductRequest = request.ProductRequest,
                OperatorId = request.OperatorId,
                Timestamp = request.Timestamp
            };

            await productsRequestRepository.CreateAsync(productsRequest);
            return productsRequest.Id;
        }
    }
}
