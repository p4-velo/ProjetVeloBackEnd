using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    // controller which gets location by latitude and longitude in the database
    [HttpGet("{latitude}&{longitude}")]
    public async Task<Location> GetByLongLat(string latitude, string longitude)
    {
        return await _locationService.GetLocationByLongLat(latitude, longitude);
    }

    // controller which displays all favorite places in the database
    [HttpGet("{id}")]
    public async Task<Location> GetById(int id)
    {
        return await _locationService.GetLocationById(id);
    }

    // controller which adds a favorite place to the database
    [HttpPost]
    public async Task<IActionResult> AddLocation(Location location)
    {
        try
        {
            await _locationService.InsertLocation(location);

            return Ok(location);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{latitude}&{longitude}")]
    public async Task<IActionResult> DeleteLocationByLongLat(string latitude, string longitude)
    {
        try
        {
            await _locationService.DeleteLocationByLongLat(latitude, longitude);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocationById(int id)
    {
        try
        {
            await _locationService.DeleteLocationById(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}