using FluentValidation;
using ParkingManagement.Application.Models;
using ParkingManagement.Application.Repositories;

namespace ParkingManagement.Application.Services;

public class ParkingService : IParkingService
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IValidator<Parking> _parkingValidator;

    public ParkingService(IParkingRepository parkingRepository, IValidator<Parking> parkingValidator)
    {
        _parkingRepository = parkingRepository;
        _parkingValidator = parkingValidator;
    }

    public async Task<bool> CreateAsync(Parking parking, CancellationToken token = default)
    {
        await _parkingValidator.ValidateAndThrowAsync(parking, cancellationToken: token);
        return await _parkingRepository.CreateAsync(parking, token);
    }

    public Task<Parking?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _parkingRepository.GetByIdAsync(id, token);
    }

    public Task<IEnumerable<Parking>> GetAllAsync(CancellationToken token = default)
    {
        return _parkingRepository.GetAllAsync(token);
    }

    public async Task<Parking?> UpdateAsync(Parking parkings, CancellationToken token = default)
    {
        await _parkingValidator.ValidateAndThrowAsync(parking, cancellationToken: token);
        var parkingExists = await _parkingRepository.ExistsByIdAsync(parking.Id, token);
        if (!parkingExists)
        {
            return null;
        }

        await _parkingRepository.UpdateAsync(parking, token);
        return parking;
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return _parkingRepository.DeleteByIdAsync(id, token);
    }
}
