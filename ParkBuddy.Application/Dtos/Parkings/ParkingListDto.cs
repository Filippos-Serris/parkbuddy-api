using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Dtos.Parkings
{
    public record ParkingListDto(Guid Id,
    string Name,
    Address Address,
    decimal PricePerHour,
    ParkingStatus Status);
}