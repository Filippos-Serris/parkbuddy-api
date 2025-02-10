using ParkBuddy.Application.Dtos;
using ParkBuddy.Domain.Entities;

namespace ParkBuddy.Application.Mappings
{
    public interface IParkingMapper
    {
        Parking RegisterDtoToParking(RegisterParkingDto parking);
    }
}