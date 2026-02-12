using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    /// <summary>
    /// Handler for processing user update commands.
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<bool>>
    {
        private readonly IUserAccountService _userAccountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserHandler"/> class.
        /// </summary>
        /// <param name="userAccountService">The user account service to use for handling user updates.</param>
        public UpdateUserHandler(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        /// <summary>
        /// Handles the user update command.
        /// </summary>
        /// <param name="command">The update user command request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task<Result<bool>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _userAccountService.UpdateUserAsync(command, cancellationToken);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message, result.Errors);
            return Result<bool>.Success(true, result.Message);
        }
    }
}