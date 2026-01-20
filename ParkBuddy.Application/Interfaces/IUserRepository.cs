using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces;

public interface IUserRepository
{
    Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand user);
}
