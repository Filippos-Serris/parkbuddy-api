using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos.Users;

namespace ParkBuddy.Application.Interfaces
{
    public interface IUserMediatorService
    {
        Task<Result<Guid>> RegisterUser(RegisterUserDto user);
    }
}
