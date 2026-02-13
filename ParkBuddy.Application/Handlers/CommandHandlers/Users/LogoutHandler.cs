using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    /// <summary>
    /// Handler for processing user logout commands.
    /// </summary>
    public class LogoutHandler : IRequestHandler<LogoutCommand, Result<bool>>
    {
        private readonly IAuthService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutHandler"/> class.
        /// </summary>
        /// <param name="service">The authentication service to use.</param>
        public LogoutHandler(IAuthService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the logout command.
        /// </summary>
        /// <param name="command">The logout command to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task<Result<bool>> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            var result = await _service.LogoutAsync(cancellationToken);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message, result.Errors);
            return Result<bool>.Success(true, result.Message);
        }
    }
}