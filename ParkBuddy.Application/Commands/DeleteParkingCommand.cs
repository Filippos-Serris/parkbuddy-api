using MediatR;
using ParkBuddy.Application.Common;

namespace ParkBuddy.Application.Commands
{
    public class DeleteParkingCommand : IRequest<Result<string>>
    {
        public Guid ParkingId { get; set; }
        public DeleteParkingCommand(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
