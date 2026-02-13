using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    public class LogoutHandler : IRequestHandler<LogoutCommand, Result<bool>>
    {
        private readonly IAuthService _repository;

        public LogoutHandler(IAuthService repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the logout command.
        /// </summary>
        /// <param name="command">The logout command to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task<Result<bool>> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.LogoutAsync(cancellationToken);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message, result.Errors);
            return Result<bool>.Success(true, result.Message);
        }
    }
}