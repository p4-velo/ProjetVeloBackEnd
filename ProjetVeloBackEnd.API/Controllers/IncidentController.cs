using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;
using ProjetVeloBackEnd.Services.Models;

namespace ProjetVeloBackEnd.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class IncidentController : Controller
{
    private readonly IIncidentService _incidentService;

    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    /// <summary>
    /// Adds an incident to the database.
    /// </summary>
    /// <param name="incident"> <see cref="Incident"/> model carrying the data to register.</param>
    /// <returns>Returns a status code 200 and the asked favorite place in case of success or status code 500 in case of failure.</returns>
    [HttpPost()]
    public async Task<IActionResult> AddIncident(Incident incident)
    {
        try
        {
            await _incidentService.AddIncident(incident);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Gets an incident by its id.
    /// </summary>
    /// <param name="id"> Id of the incident we want.</param>
    /// <returns>Returns a status code 200 and the asked favorite place in case of success or status code 500 in case of failure.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIncidentById(int id)
    {
        try
        {
            var favoritePlace = await _incidentService.GetIncidentById(id);
            return Ok(favoritePlace);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Gets all active incidents.
    /// </summary>
    /// <returns>Returns a List of incidents in a 200 status code, otherwise returns a 500 status code.</returns>
    [HttpGet()]
    public async Task<IActionResult> GetActiveIncidents()
    {
        try
        {
            var listIncidents = await _incidentService.GetActiveIncidents();
            return Ok(listIncidents);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Update an incident finisher count in the database.
    /// </summary>
    /// <param name="id">Id of the incident that we want to increment the finisher counter.</param>
    /// <returns>Returns a status code 200 and the asked favorite place in case of success or status code 500 in case of failure.</returns>
    [HttpPut("{id}")] /// revoir le mot http en patch
    public async Task<IActionResult> IncrementIncidentCount(int id)
    {
        try
        {
            await _incidentService.IncrementCountIncident(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}