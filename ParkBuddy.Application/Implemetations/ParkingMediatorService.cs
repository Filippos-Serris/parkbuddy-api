using MediatR;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Implemetations
{
    public class ParkingMediatorService : IParkingMediatorService
    {
        private readonly IMediator mediator;

        public ParkingMediatorService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Result<GetParkingListQueryResult>> GetParkings()
        {
            return await mediator.Send(new GetParkingListQuery());
        }

        public async Task<Result<GetParkingQueryResult>> GetParking(Guid parkingId)
        {
            return await mediator.Send(new GetParkingQuery(parkingId));
        }

        public async Task<Result<Guid>> RegisterParking(RegisterParkingCommand parking)
        {
            return await mediator.Send(parking);
        }

        public async Task<Result<bool>> DeleteParking(Guid parkingId)
        {
            return await mediator.Send(new DeleteParkingCommand(parkingId));
        }

        public async Task<Result<ParkingDto>> UpdateParking(UpdateParkingCommand parking)
        {
            return await mediator.Send(parking);
        }
    }
}
