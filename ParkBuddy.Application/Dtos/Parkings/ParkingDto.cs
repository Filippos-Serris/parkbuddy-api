using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.ValueObjects;

namespace ParkBuddy.Application.Dtos.Parkings;

public record ParkingDto(
    Guid Id,
    string Name,
    Address Address,
    int Capacity,
    decimal PricePerHour,
    ParkingStatus Status);
