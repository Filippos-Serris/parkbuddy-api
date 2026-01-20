using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.CommandHandlers;

public class DeleteParkingHandler : IRequestHandler<DeleteParkingCommand, Result<bool>>
{
    private readonly IParkingRepository _repository;

    public DeleteParkingHandler(IParkingRepository repository)
    {
        this._repository = repository;
    }

    public async Task<Result<bool>> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteParkingAsync(request.ParkingId);

        if (!result.IsSuccess)
            return Result<bool>.Failure(result.Message);
        return Result<bool>.Success(result.Data, result.Message);
    }
}
