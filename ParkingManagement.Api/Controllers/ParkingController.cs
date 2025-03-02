using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Api.Mapping;
using ParkingManagement.Application.Repositories;
using ParkingManagement.Application.Services;
using ParkingManagement.Contracts.Requests;

namespace ParkingManagement.Api.Controllers;

[ApiController]
public class ParkingController : ControllerBase
{
    private readonly IParkingService _parkingService;

    public ParkingController(IParkingService parkingService)
    {
        _parkingService = parkingService;
    }

    [HttpPost(ApiEndpoints.Parkings.Create)]
    public async Task<IActionResult> Create([FromBody] CreateParkingRequest request,
        CancellationToken token)
    {
        var parking = request.MapToParking();
        await _parkingService.CreateAsync(parking, token);
        var parkingResponse = parking.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = parking.Id }, parkingResponse);
    }

    [HttpGet(ApiEndpoints.Parkings.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id,
        CancellationToken token)
    {
        var parking = await _parkingService.GetByIdAsync(id, token);
        if (parking is null)
        {
            return NotFound();
        }

        var response = parking.MapToResponse();
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Parkings.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var parkings = await _parkingService.GetAllAsync(token);

        var parkingResponse = parkings.MapToResponse();
        return Ok(parkingResponse);
    }

    [HttpPut(ApiEndpoints.Parkings.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id,
        [FromBody] UpdateParkingRequest request,
        CancellationToken token)
    {
        var parking = request.MapToParking(id);
        var updatedParking = await _parkingService.UpdateAsync(parking, token);
        if (updatedParking is null)
        {
            return NotFound();
        }

        var response = updatedParking.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Parkings.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id,
        CancellationToken token)
    {
        var deleted = await _parkingService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
