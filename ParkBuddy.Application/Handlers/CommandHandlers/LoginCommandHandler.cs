using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseCommand>>
    {
        private readonly IAuthRepository repository;
        private readonly IJwtTokenService tokenService;
        public LoginCommandHandler(IAuthRepository repository, IJwtTokenService tokenService)
        {
            this.repository = repository;
            this.tokenService = tokenService;
        }

        public async Task<Result<LoginResponseCommand>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var login = await repository.LoginAsync(request);

            if (!login.IsSuccess)
                return Result<LoginResponseCommand>.Failure(login.Message);

            var token = tokenService.GenerateToken(login.Data.Id, request.Email, login.Data.Role.ToString());

            var result = new LoginResponseCommand(login.Data.Id, login.Data.Role, token);

            return Result<LoginResponseCommand>.Success(result, login.Message);
        }
    }
}
