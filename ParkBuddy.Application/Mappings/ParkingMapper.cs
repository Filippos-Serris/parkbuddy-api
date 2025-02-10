using ParkBuddy.Application.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Mappings
{
    public class ParkingMapper : IParkingMapper
    {
        public Parking RegisterDtoToParking(RegisterParkingDto parking)
        {
            var parkingDto = new Parking
            {
                ParkingId = Guid.NewGuid(),
                Name = parking.Name,
                Address = parking.Address,
                Capacity = parking.Capacity,
                PricePerHour = parking.PricePerHour,
                Status = Domain.Enums.ParkingStatus.Open
            };

            return parkingDto;
        }
    }
}