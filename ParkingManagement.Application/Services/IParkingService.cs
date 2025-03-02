using ParkingManagement.Application.Models;

namespace ParkingManagement.Application.Services;

public interface IParkingService
{
    Task<bool> CreateAsync(Parking parking, CancellationToken token = default);

    Task<Parking?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Parking>> GetAllAsync(CancellationToken token = default);

    Task<Parking?> UpdateAsync(Parking parking, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
