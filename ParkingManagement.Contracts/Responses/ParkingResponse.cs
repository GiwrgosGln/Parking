namespace ParkingManagement.Contracts.Responses;

public class ParkingResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string City { get; init; }
}