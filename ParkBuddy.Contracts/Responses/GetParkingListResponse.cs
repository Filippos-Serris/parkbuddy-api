using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Contracts.Responses
{
    public record GetParkingListResponse(Result<List<ParkingList>> Result);

    public record ParkingList(
        Guid Id,
        string Name,
        string Address,
        decimal PricePerHour,
        string Status
    );
}