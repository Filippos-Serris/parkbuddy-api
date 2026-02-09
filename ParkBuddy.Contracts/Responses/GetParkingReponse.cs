using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Responses
{
    public record GetParkingResponse(ParkingItem Parking);

    public record ParkingItem(
        Guid Id,
        string Name,
        string Address,
        int Capacity,
        decimal PricePerHour,
        ParkingStatus Status);
}