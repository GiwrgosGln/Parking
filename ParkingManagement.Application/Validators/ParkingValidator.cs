using FluentValidation;
using ParkingManagement.Application.Models;
using ParkingManagement.Application.Repositories;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Application.Validators;

public class ParkingValidator : AbstractValidator<Parking>
{
    private readonly IParkingRepository _parkingRepository;

    public MovieValidator(IParkingRepository parkingRepository)
    {
        _parkingRepository = parkingRepository;
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Address)
            .NotEmpty();

        RuleFor(x => x.City)
            .NotEmpty();
    }
}
