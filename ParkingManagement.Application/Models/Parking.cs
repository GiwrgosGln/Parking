using System.Text.RegularExpressions;

namespace ParkingManagement.Application.Models;

public partial class Parking
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
    public required string City { get; init; }
}