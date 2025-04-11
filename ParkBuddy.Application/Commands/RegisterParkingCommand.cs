using MediatR;
using ParkBuddy.Application.Dtos;

namespace ParkBuddy.Application.Commands
{
    public class RegisterParkingCommand: IRequest<Unit>
    {
        public RegisterParkingDto ParkingDto { get; set; }

        public RegisterParkingCommand(RegisterParkingDto parking) 
        {
            ParkingDto = parking;
        }
    }
}
