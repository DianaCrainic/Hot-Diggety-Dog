using MediatR;
using System;

namespace Application.Features.UserFeatures.Command
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
