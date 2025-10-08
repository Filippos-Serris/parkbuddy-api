using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseCommand>>
    {
        private readonly IAuthRepository repository;
        public LoginCommandHandler(IAuthRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<LoginResponseCommand>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.LoginAsync(request);

            if (result.IsSuccess)
                return Result<LoginResponseCommand>.Success(result.Data, result.Message);
            return Result<LoginResponseCommand>.Failure(result.Message);
        }
    }
}
