using ParkingManagement.Application.Models;
using ParkingManagement.Contracts.Requests;
using ParkingManagement.Contracts.Responses;

namespace ParkingManagement.Api.Mapping;

public static class ContractMapping
{
    public static Parking MapToParking(this CreateParkingRequest request)
    {
        return new Parking
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            City = request.City,
        };
    }

    public static Parking MapToParking(this UpdateParkingRequest request, Guid id)
    {
        return new Parking
        {
            Id = id,
            Name = request.Name,
            Address = request.Address,
            City = request.City,
        };
    }

    public static ParkingResponse MapToResponse(this Parking parking)
    {
        return new ParkingResponse
        {
            Id = parking.Id,
            Name = parking.Name,
            Address = parking.Address,
            City = parking.City,
        };
    }

    public static ParkingsResponse MapToResponse(this IEnumerable<Parking> parkings)
    {
        return new ParkingsResponse
        {
            Items = parkings.Select(MapToResponse)
        };
    }
}
