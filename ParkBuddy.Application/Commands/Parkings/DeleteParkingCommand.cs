using MediatR;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Commands.Parkings
{
    public class DeleteParkingCommand : IRequest<Result<bool>>
    {
        public Guid ParkingId { get; set; }
        public DeleteParkingCommand(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
