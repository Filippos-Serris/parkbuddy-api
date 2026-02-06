using ParkBuddy.Contracts.Common;
using ParkBuddy.Contracts.Enums;

namespace ParkBuddy.Contracts.Responses
{
    public record GetParkingResponse(Result<ParkingItem> Result);

    public record ParkingItem(
        Guid Id,
        string Name,
        string Address,
        int Capacity,
        decimal PricePerHour,
        ParkingStatus Status);
}