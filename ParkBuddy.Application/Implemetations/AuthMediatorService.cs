using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Implemetations
{
    public class AuthMediatorService : IAuthMediatorService
    {
        private readonly IMediator mediator;
        public AuthMediatorService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Result<LoginResponseCommand>> Login(LoginCommand command)
        {
           return await mediator.Send(command);
        }
    }
}
