using MediatR;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Handlers.QueryHandlers
{
    public class GetParkingListHandler : IRequestHandler<GetParkingListQuery, Result<GetParkingListQueryResult>>
    {
        private readonly IParkingRepository repository;

        public GetParkingListHandler(IParkingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<GetParkingListQueryResult>> Handle(GetParkingListQuery query, CancellationToken cancellationToken)
        {
            var parkingList = await repository.GetParkingListAsync();

            if (parkingList.IsSuccess)
                return Result<GetParkingListQueryResult>.Success(new GetParkingListQueryResult(parkingList.Data), parkingList.Message);
            return Result<GetParkingListQueryResult>.Failure(parkingList.Message);
        }
    }
}