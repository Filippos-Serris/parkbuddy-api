using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Contracts.Responses
{
    public record GetParkingListResponse(Result<List<ParkingListItem>> Result);

    public record ParkingListItem(
        Guid Id,
        string Name,
        string Address,
        decimal PricePerHour,
        string Status
    );
}