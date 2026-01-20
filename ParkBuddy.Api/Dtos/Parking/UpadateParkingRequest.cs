using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Api.Dtos.Parking;

public record UpadateParkingRequest(
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour,
    ParkingStatus Status)
{
}
