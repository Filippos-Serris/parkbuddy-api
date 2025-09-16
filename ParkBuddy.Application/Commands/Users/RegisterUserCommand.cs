using MediatR;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos.Users;

namespace ParkBuddy.Application.Commands.Users
{
    public record RegisterUserCommand(
        RegisterUserDto userDto) : IRequest<Result<Guid>>;
}
