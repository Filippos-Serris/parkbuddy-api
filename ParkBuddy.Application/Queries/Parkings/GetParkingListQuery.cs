using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings;

/// <summary>
/// Represents a query to retrieve a list of parkings with their details.
/// </summary>
public record GetParkingListQuery() : IRequest<Result<List<ParkingListDto>>>;