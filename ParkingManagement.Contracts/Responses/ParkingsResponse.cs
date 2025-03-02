namespace ParkingManagement.Contracts.Responses;

public class ParkingsResponse
{
    public required IEnumerable<ParkingResponse> Items { get; init; } = Enumerable.Empty<ParkingResponse>();
}