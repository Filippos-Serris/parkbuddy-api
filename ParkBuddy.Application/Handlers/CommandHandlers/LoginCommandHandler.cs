using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseCommand>>
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtTokenService _tokenService;
        public LoginCommandHandler(IAuthRepository repository, IJwtTokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponseCommand>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var login = await _repository.LoginAsync(request);

            if (!login.IsSuccess)
                return Result<LoginResponseCommand>.Failure(login.Message);

            var token = _tokenService.GenerateToken(login.Data.Id, request.Email, login.Data.Role.ToString());

            var result = new LoginResponseCommand(login.Data.Id, login.Data.Role, token);

            return Result<LoginResponseCommand>.Success(result, login.Message);
        }
    }
}
