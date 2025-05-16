using System.Data;
using FluentValidation;
using ParkBuddy.Contracts.Dtos;

namespace ParkBuddy.Application.Validation
{
    public class RegisterParkingDtoValidator : AbstractValidator<RegisterParkingDto>
    {
        public RegisterParkingDtoValidator()
        {
            RuleFor(parking => parking.Name).NotEmpty().WithMessage("Name must not be empty.");
            RuleFor(parking => parking.Name).Length(5, 15).WithMessage("Name must be between 5-15 characters");
        }
    }
}