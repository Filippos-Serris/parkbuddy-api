﻿using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Contracts;
using ParkBuddy.Contracts.Dtos;
using ParkBuddy.Contracts.Enums;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;

namespace ParkBuddy.Infrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkBuddyContext context;

        public ParkingRepository(ParkBuddyContext context)
        {
            this.context = context;
        }

        public async Task<Result<List<ParkingDto>>> GetParkingListAsync()
        {
            var result = await context.Parkings
                .Select(p => new ParkingDto
                {
                    ParkingId = p.ParkingId,
                    Name = p.Name,
                    Address = p.Address,
                    Capacity = p.Capacity,
                    PricePerHour = p.PricePerHour,
                    Status = p.Status,
                }).
                ToListAsync();

            if (result == null)
                return Result<List<ParkingDto>>.Failure("Parkings not retrieved.");
            return Result<List<ParkingDto>>.Success(result, "Parkings retrieved succeffully");
        }

        public async Task<Result<ParkingDto>> GetParkingAsync(Guid ParkingId)
        {
            var result = await context.Parkings
                .Where(p => p.ParkingId == ParkingId)
                .Select(p => new ParkingDto
                {
                    ParkingId = p.ParkingId,
                    Name = p.Name,
                    Address = p.Address,
                    Capacity = p.Capacity,
                    PricePerHour = p.PricePerHour,
                    Status = p.Status
                })
                .FirstOrDefaultAsync();

            if (result == null)
                return Result<ParkingDto>.Failure("Parking not retrieved.");
            return Result<ParkingDto>.Success(result, "Parking retrieved succeffully");
        }

        public async Task<Result<Guid>> RegisterParkingAsync(RegisterParkingDto parking)
        {

            var newParking = new Parking
            {
                ParkingId = Guid.NewGuid(),
                Name = parking.Name,
                Address = parking.Address,
                Capacity = parking.Capacity,
                PricePerHour = parking.PricePerHour
            };

            context.Add(newParking);
            var result = await context.SaveChangesAsync() > 0;

            if (result)
                return Result<Guid>.Success(newParking.ParkingId, "Parkign registered successfully");
            return Result<Guid>.Failure("Failed to register p");
        }

        public async Task<Result<string>> DeleteParkingAsync(Guid parkingId)
        {
            var result = await context.Parkings.Where(p => p.ParkingId == parkingId).ExecuteDeleteAsync() > 0;

            if (result)
                return Result<string>.Success("Deleted", "Parking deleted successfully");
            return Result<string>.Failure("Failed to delete p");
        }

        public async Task<Result<ParkingDto>> UpdateParkingAsync(UpdateParkingDto updateParking)
        {
            var parking = await context.Parkings.FindAsync(updateParking.ParkingId);

            if (parking == null)
                return Result<ParkingDto>.Failure("Failed to delete p");

            parking.Name = updateParking.Name;
            parking.Address = updateParking.Address;
            parking.Capacity = updateParking.Capacity;
            parking.PricePerHour = updateParking.PricePerHour;
            parking.Status = updateParking.Status;

            var result = await context.SaveChangesAsync() > 0;

            if (result)
            {
                var updatedParking = new ParkingDto
                {
                    ParkingId = parking.ParkingId,
                    Name = parking.Name,
                    Capacity = parking.Capacity,
                    PricePerHour = parking.PricePerHour,
                    Status = parking.Status,
                };
                return Result<ParkingDto>.Success(updatedParking, "Parking updated successfully");
            }    
            return Result<ParkingDto>.Failure("Failed to update parking");           
        }
    }
}
