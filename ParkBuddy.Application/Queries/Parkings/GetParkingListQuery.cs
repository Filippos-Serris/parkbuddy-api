using MediatR;
using ParkBuddy.Application.Dtos.Parkings;
using ParkBuddy.Contracts.Common;

namespace ParkBuddy.Application.Queries.Parkings;

public record GetParkingListQuery() : IRequest<Result<List<ParkingListDto>>>;