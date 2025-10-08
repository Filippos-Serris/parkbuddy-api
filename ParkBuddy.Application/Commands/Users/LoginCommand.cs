using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users
{
    public record LoginCommand(string Email, string Password): IRequest<Result<LoginResponseCommand>>
    {
    }
}
