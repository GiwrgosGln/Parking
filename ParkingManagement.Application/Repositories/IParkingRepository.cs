using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ParkingManagement.Application.Models;

namespace ParkingManagement.Application.Repositories
{
    public interface IParkingRepository
    {
        Task<bool> CreateAsync(Parking parking, CancellationToken token = default);

        Task<Parking?> GetByIdAsync(Guid id, CancellationToken token = default);

        Task<IEnumerable<Parking>> GetAllAsync(CancellationToken token = default);

        Task<bool> UpdateAsync(Parking parking, CancellationToken token = default);

        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
    }
}
