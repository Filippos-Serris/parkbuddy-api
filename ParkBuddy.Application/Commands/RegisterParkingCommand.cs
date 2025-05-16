using MediatR;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Commands
{
    public class RegisterParkingCommand: IRequest<Result<Guid>>
    {
        public RegisterParkingDto ParkingDto { get; set; }

        public RegisterParkingCommand(RegisterParkingDto parking) 
        {
            ParkingDto = parking;
        }
    }
}
