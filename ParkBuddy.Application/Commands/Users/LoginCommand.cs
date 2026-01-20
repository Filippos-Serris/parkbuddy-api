using MediatR;
using ParkBuddy.Application.Results;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Users;

public record LoginCommand(string Email, string Password) : IRequest<Result<LoginResult>>
{
}
