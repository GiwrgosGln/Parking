using Dapper;
using ParkingManagement.Application.Models;
using ParkingManagement.Application.Database;

namespace ParkingManagement.Application.Repositories;

public class ParkingRepository : IParkingRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    private ParkingRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> CreateAsync(Parking parking, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            insert into parkings (id, name, address, city)
            values (@Id, @Name, @Address, @City)
        """, parking, cancellationToken: token));

        transaction.Commit();

        return result > 0;
    }

    public async Task<Parking?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var parking = await connection.QuerySingleOrDefaultAsync<Parking>(
            new CommandDefinition("""
            select * from parkings where id = @id
            """, new { id }, cancellationToken: token));

        if (parking is null)
        {
            return null;
        }

        return parking;
    }

    public async Task<IEnumerable<Parking>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var result = await connection.QueryAsync(new CommandDefinition("""
            select * from parkings
            """, cancellationToken: token));

        return result.Select(x => new Parking
        {
            Id = x.id,
            Name = x.Name,
            Address = x.Address,
            City = x.City
        });
    }

    public async Task<bool> UpdateAsync(Parking parking, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            update parking set name = @Name, address = @Address, city = @City 
            where id = @Id
            """, parking, cancellationToken: token));

        transaction.Commit();
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            delete from parkings where id = @id
            """, new { id }, cancellationToken: token));

        transaction.Commit();
        return result > 0;
    }

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        return await connection.ExecuteScalarAsync<bool>(new CommandDefinition("""
            select count(1) from parkings where id = @id
            """, new { id }, cancellationToken: token));
    }
}
