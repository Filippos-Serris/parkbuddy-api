using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<Result<LoginResponseCommand>> LoginAsync(LoginCommand command);
    }
}
