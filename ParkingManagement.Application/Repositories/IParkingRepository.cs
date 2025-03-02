using ParkingManagement.Application.Models;

namespace ParkingManagement.Application.Repositories;

public interface IParkingRepository
{
    Task<bool> CreateAsync(Parking parking, Cancellation token = default);
    Task<Parking?> GetByIdAsync(Guid id, Cancellation token = default);
    Task<IEnumerable<Parking>> GetAllAsync(CancellationToken token = default);
    Task<bool> UpdateAsync(Parking parking, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}