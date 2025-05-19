using MediatR;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Commands
{
    public class UpdateParkingCommand: IRequest<Result<ParkingDto>>
    {
        public UpdateParkingDto ParkingDto { get; set; }

        public UpdateParkingCommand(UpdateParkingDto parkingDto) 
        {
            ParkingDto = parkingDto;
        }
    }
}
