using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;
using ProjetVeloBackEnd.Services.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        var location = _locationService.GetLocationByLongLat(latitude, longitude);

        return location;
    }

    // controller which displays all favorite places in the database
    [HttpGet("{id}")]
    public async Task<Location> GetById(int id)
    {
        var location = _locationService.GetLocationById(id);

        return location;
    }

    // controller which adds a favorite place to the database
    [HttpPost]
    public async Task<IActionResult> AddLocation(Location location)
    {
        try
        {
            _locationService.InsertLocation(location);

            return Ok();
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
            _locationService.DeleteLocationByLongLat(latitude, longitude);
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
            _locationService.DeleteLocationById(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}