using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces;

public interface IUserAccountService
{
    Task<Result<Guid>> RegisterUserAsync(RegisterUserCommand user, CancellationToken cancellationToken);
}
