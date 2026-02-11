using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Commands.Parkings;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts.Common;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories;

public class ParkingRepository : IParkingRepository
{
    private readonly ParkBuddyContext _context;

    public ParkingRepository(ParkBuddyContext context)
    {
        _context = context;
    }

    public async Task<Result<List<ParkingListDto>>> GetParkingListAsync(CancellationToken cancellationToken)
    {
        var parkings = await _context.Parkings
        .AsNoTracking()
            .Select(p => new ParkingListDto(
                p.ParkingId,
                p.Name,
                p.Address,
                p.PricePerHour,
                p.Status))
            .ToListAsync(cancellationToken);

        return Result<List<ParkingListDto>>.Success(
            parkings,
            parkings.Count != 0 ? "Parkings retrieved successfully" : "No parkings found");
    }

    public async Task<Result<ParkingDto>> GetParkingAsync(Guid parkingId, CancellationToken cancellationToken)
    {
        var result = await _context.Parkings
        .AsNoTracking()
            .Where(p => p.ParkingId == parkingId)
            .Select(p => new ParkingDto(
                p.ParkingId,
                p.Name,
                p.Address,
                p.Capacity,
                p.PricePerHour,
                p.Status))
            .SingleOrDefaultAsync(cancellationToken);

        if (result == null)
            return Result<ParkingDto>.Failure($"Parking with {parkingId} id not found");
        return Result<ParkingDto>.Success(result, "Parking retrieved successfully");
    }

    public async Task<Result<Guid>> RegisterParkingAsync(RegisterParkingCommand command, CancellationToken cancellationToken)
    {
        var newParking = new Parking
        {
            ParkingId = Guid.NewGuid(),
            Name = command.Name,
            Address = command.Address,
            Capacity = command.Capacity,
            PricePerHour = command.PricePerHour,
        };

        _context.Add(newParking);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;

        if (result)
            return Result<Guid>.Success(newParking.ParkingId, "Parking registered successfully");
        return Result<Guid>.Failure("Failed to register parking");
    }

    public async Task<Result<bool>> DeleteParkingAsync(Guid parkingId, CancellationToken cancellationToken)
    {
        var result = await _context.Parkings.Where(p => p.ParkingId == parkingId).ExecuteDeleteAsync(cancellationToken) > 0;

        if (result)
            return Result<bool>.Success(true, "Parking deleted successfully");
        return Result<bool>.Failure("Failed to delete p");
    }

    public async Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingCommand command, CancellationToken cancellationToken)
    {
        var parking = await _context.Parkings.FindAsync(command.Id);

        if (parking == null)
            return Result<ParkingDto>.Failure("Parking not found, failed to update.");

        parking.Name = command.Name;
        parking.Address = command.Address;
        parking.Capacity = command.Capacity;
        parking.PricePerHour = command.PricePerHour;
        parking.Status = command.Status;

        var result = await _context.SaveChangesAsync(cancellationToken) > 0;

        if (result)
        {
            return Result<ParkingDto>.Success(
                new ParkingDto(
                    parking.ParkingId,
                    parking.Name,
                    parking.Address,
                    parking.Capacity,
                    parking.PricePerHour,
                    parking.Status),
                "Parking updated successfully");
        }

        return Result<ParkingDto>.Failure("Failed to update parking");
    }
}
