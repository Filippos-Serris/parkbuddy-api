using MediatR;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, Result<GetParkingListQueryResult>>
    {
        private readonly IParkingRepository _repository;

        public GetParkingListHandler(IParkingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetParkingListQueryResult>> Handle(GetParkingListQuery query, CancellationToken cancellationToken)
        {
            var parkingList = await _repository.GetParkingListAsync();

            if (parkingList.IsSuccess)
                return Result<GetParkingListQueryResult>.Success(new GetParkingListQueryResult(parkingList.Data), parkingList.Message);
            return Result<GetParkingListQueryResult>.Failure(parkingList.Message);
        }
    }
}