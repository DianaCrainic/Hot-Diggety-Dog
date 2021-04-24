using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.UserFeatures.Command
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
}
