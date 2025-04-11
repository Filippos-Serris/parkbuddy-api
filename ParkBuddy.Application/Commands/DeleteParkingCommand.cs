using MediatR;

namespace ParkBuddy.Application.Commands
{
    public class DeleteParkingCommand : IRequest<Unit>
    {
        public Guid ParkingId { get; set; }
        public DeleteParkingCommand(Guid parkingId)
        {
            ParkingId = parkingId;
        }
    }
}
