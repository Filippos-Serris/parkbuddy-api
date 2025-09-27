using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Application.Dtos.Parkings
{
    public record ParkingDto(
        Guid Id, 
        string Name, 
        string Address, 
        int Capacity, 
        decimal PricePerHour, 
        ParkingStatus Status)
    {
    }
}
