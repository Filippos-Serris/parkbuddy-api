using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Dtos.User;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces;

public interface IAuthRepository
{
    Task<Result<LoginDto>> LoginAsync(LoginCommand command);
}
