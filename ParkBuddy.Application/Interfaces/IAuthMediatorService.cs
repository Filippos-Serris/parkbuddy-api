using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Interfaces
{
    public interface IAuthMediatorService
    {
        Task<Result<LoginResponseCommand>> Login(LoginCommand command);
    }
}
