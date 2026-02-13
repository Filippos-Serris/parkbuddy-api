using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.QueryHandlers;

public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, Result<List<ParkingListDto>>>
{
    private readonly IParkingRepository _repository;

    public GetParkingListHandler(IParkingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<ParkingListDto>>> Handle(GetParkingListQuery query, CancellationToken cancellationToken)
    {
        var parkingList = await _repository.GetParkingListAsync(cancellationToken);

        if (parkingList.IsSuccess)
            return Result<List<ParkingListDto>>.Success(parkingList.Data, parkingList.Message);
        return Result<List<ParkingListDto>>.Failure(parkingList.Message);
    }
}