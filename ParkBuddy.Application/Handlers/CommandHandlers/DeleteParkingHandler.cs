using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers;

/// <summary>
/// Represents a handler for the DeleteParkingCommand.
/// </summary>
public class DeleteParkingHandler : IRequestHandler<DeleteParkingCommand, Result<bool>>
{
    private readonly IParkingRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteParkingHandler"/> class.
    /// </summary>
    /// <param name="repository">The parking repository to use for handling the command.</param>
    public DeleteParkingHandler(IParkingRepository repository)
    {
        this._repository = repository;
    }

    /// <summary>
    /// Handles the DeleteParkingCommand.
    /// </summary>
    /// <param name="request">The delete parking command to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    public async Task<Result<bool>> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteParkingAsync(request.ParkingId, cancellationToken);

        if (!result.IsSuccess)
            return Result<bool>.Failure(result.Message);
        return Result<bool>.Success(result.Data, result.Message);
    }
}
