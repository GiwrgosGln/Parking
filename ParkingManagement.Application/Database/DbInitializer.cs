using Dapper;

namespace ParkingManagement.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync("""
            create table if not exists parkings (
            id UUID primary key,
            name TEXT not null,
            address TEXT not null,
            city TEXT not null);
        """);
    }
}
