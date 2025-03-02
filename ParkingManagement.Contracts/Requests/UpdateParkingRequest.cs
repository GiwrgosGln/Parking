namespace ParkingManagement.Contracts.Requests;

public class UpdateParkingRequest
{
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string City { get; init; }
}