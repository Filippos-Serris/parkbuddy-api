using MediatR;
using ParkBuddy.Application.Commands.Users;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers.Users
{
    /// <summary>
    /// Handler for updating a user's password.
    /// </summary>
    public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, Result<bool>>
    {
        private readonly IUserAccountService _userAccountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserPasswordHandler"/> class.
        /// </summary>
        /// <param name="userAccountService">The user account service to use for handling user password updates.</param>
        public UpdateUserPasswordHandler(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        /// <summary>
        /// Handles the update of a user's password.
        /// </summary>
        /// <param name="command">The command containing user password update details.</param>
        /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
        /// <returns>A result indicating success or failure of the password update operation.</returns>
        public async Task<Result<bool>> Handle(UpdateUserPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _userAccountService.UpdateUserPasswordAsync(command, cancellationToken);

            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Message, result.Errors);
            return Result<bool>.Success(true, result.Message);
        }
    }
}