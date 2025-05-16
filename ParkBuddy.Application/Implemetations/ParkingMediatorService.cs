using MediatR;
using ParkBuddy.Application.Commands;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Queries;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Implemetations
{
    public class ParkingMediatorService : IParkingMediatorService
    {
        private readonly IMediator mediator;

        public ParkingMediatorService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Result<List<ParkingDto>>> GetParkings()
        {
            return await mediator.Send(new GetParkingListQuery());
        }

        public async Task<Result<ParkingDto>> GetParking(Guid parkingId)
        {
            return await mediator.Send(new GetParkingQuery(parkingId));
        }

        public async Task<Result<Guid>> RegisterParking(RegisterParkingDto parking)
        {
            return await mediator.Send(new RegisterParkingCommand(parking));
        }

        public async Task<Result<string>> DeleteParking(Guid parkingId)
        {
            return await mediator.Send(new DeleteParkingCommand(parkingId));
        }
    }
}
