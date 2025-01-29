using ParkBuddy.Application.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Mappings
{
    public class ParkingMapper : IParkingMapper
    {
        public ParkingDto MapToDto(Parking parking)
        {
            var parkingDto = new ParkingDto
            {
                Id = parking.ParkingId,
                Name = parking.Name,
                Address = parking.Address,
                Capacity = parking.Capacity,
                PricePerHour = parking.PricePerHour
            };
            return parkingDto;
        }

        public List<ParkingDto> MapToListDto(List<Parking> parkings)
        {
            var parkingDtos = parkings.Select(parking => new ParkingDto
            {
                Id = parking.ParkingId,
                Name = parking.Name,
                Address = parking.Address,
                Capacity = parking.Capacity,
                PricePerHour = parking.PricePerHour
            }).ToList();

            return parkingDtos;
        }
    }
}