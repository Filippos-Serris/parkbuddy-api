using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.QueryHandlers;

public class GetParkingHandler : IRequestHandler<GetParkingQuery, Result<ParkingDto>>
{
    private readonly IParkingRepository _repository;

    public GetParkingHandler(IParkingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ParkingDto>> Handle(GetParkingQuery query, CancellationToken cancellationToken)
    {
        var result = await _repository.GetParkingAsync(query.ParkingId, cancellationToken);

        if (result.IsSuccess)
            return Result<ParkingDto>.Success(result.Data, result.Message);
        return Result<ParkingDto>.Failure(result.Message);
    }
}
