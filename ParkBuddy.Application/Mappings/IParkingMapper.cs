using ParkBuddy.Application.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Mappings
{
    public interface IParkingMapper
    {
        /*ParkingDto MapToDto(Parking parking);
        List<ParkingDto> MapToListDto(List<Parking> parkings);*/

        Parking RegisterDtoToParking(RegisterParkingDto parking);
    }
}