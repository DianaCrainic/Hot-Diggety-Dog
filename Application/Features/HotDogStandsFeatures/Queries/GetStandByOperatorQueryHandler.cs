using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HotDogStandsFeatures.Queries
{
    public class GetStandByOperatorQueryHandler : IRequestHandler<GetStandByOperatorQuery, HotDogStand>
    {
        private readonly IHotDogStandRepository standRepository;

        public GetStandByOperatorQueryHandler(IHotDogStandRepository standRepository)
        {
            this.standRepository = standRepository;
        }


        public async Task<HotDogStand> Handle(GetStandByOperatorQuery request, CancellationToken cancellationToken)
        {
            return await standRepository.GetStandByOperatorId(request.OperatorId);
        }
    }
}
