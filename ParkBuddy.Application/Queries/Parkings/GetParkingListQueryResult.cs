using ParkBuddy.Application.Dtos.Parkings;

namespace ParkBuddy.Application.Queries.Parkings;

public record GetParkingListQueryResult(List<ParkingDto> Parkings)
{
}
