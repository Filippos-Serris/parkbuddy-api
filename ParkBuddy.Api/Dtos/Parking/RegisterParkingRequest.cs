using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Api.Dtos.Parking
{
    public record RegisterParkingRequest(
        string Name,
        Address Address,
        int Capacity,
        decimal PricePerHour);
}
