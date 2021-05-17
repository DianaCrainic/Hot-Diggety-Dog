using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StandProductsFeatures.Commands
{
    class DeleteStandProductCommandHandler : IRequestHandler<DeleteStandProductCommand, Guid>
    {
        private readonly IStandProductRepository _standProductRepository;

        public UpdateStandProductCommandHandler(IStandProductRepository standProductRepository)
        {
            _standProductRepository = standProductRepository;
        }


        public async Task<Guid> Handle(DeleteStandCommand request, CancellationToken cancellationToken)
        {
            HotDogStand stand = await standRepository.GetByIdAsync(request.Id);

            if (stand == null)
            {
                return Guid.Empty;
            }

            await standRepository.RemoveAsync(stand);
            return stand.Id;
        }
    }
}
