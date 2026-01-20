using MediatR;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.QueryHandlers;

public class GetParkingHandler : IRequestHandler<GetParkingQuery, Result<GetParkingQueryResult>>
{
    private readonly IParkingRepository _repository;

    public GetParkingHandler(IParkingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetParkingQueryResult>> Handle(GetParkingQuery query, CancellationToken cancellationToken)
    {
        var result = await _repository.GetParkingAsync(query.ParkingId);

        if (result.IsSuccess)
            return Result<GetParkingQueryResult>.Success(new GetParkingQueryResult(result.Data), result.Message);
        return Result<GetParkingQueryResult>.Failure(result.Message);
    }
}
