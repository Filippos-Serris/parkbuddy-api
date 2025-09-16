using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Contracts;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.userDto.Email,
                Email = request.userDto.Email,
                FirstName = request.userDto.FirstName,
                LastName = request.userDto.LastName
            };

            var result = await _userManager.CreateAsync(user, request.userDto.Password);

            if (result.Succeeded == true)
                return Result<Guid>.Success(user.Id, "Successful registration");
            return Result<Guid>.Failure("Registeaton failed");
        }
    }
}
