using MediatR;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Commands.Users
{
    public record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        Roles Role) : IRequest<Result<Guid>>;
}
