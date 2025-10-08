using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Implemetations
{
    public class UserMediatorService : IUserMediatorService
    {
        private readonly IMediator meditor;

        public UserMediatorService(IMediator mediator)
        {
            this.meditor = mediator;
        }

        public async Task<Result<Guid>> RegisterUser(RegisterUserCommand user)
        {
            return await meditor.Send(user);
        }
    }
}
