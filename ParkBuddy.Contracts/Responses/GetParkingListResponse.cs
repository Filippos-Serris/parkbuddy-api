namespace ParkBuddy.Contracts.Responses
{
    public record GetParkingListResponse(List<ParkingListItem> ParkingList);

    public record ParkingListItem(
        Guid Id,
        string Name,
        string Address,
        decimal PricePerHour,
        string Status
    );
}