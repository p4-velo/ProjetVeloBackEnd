using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;

namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class PlaceController : Controller
{
    private readonly ICRUDService<Place> _placeService;

    public PlaceController(ICRUDService<Place> placeService)
    {
        _placeService = placeService;
    }

    // controller which displays all places in the database
    [HttpGet]
    public async Task<IList<Place>> GetAll()
    {
        return await _placeService.GetAll();
    }

    // controller which displays a place by its id
    [HttpGet("{id}")]
    public async Task<Place?> Get(int id)
    {
        return await _placeService.Get(p => p.Id == id);
    }
    
    // controller which adds a place to the database
    [HttpPost]
    public async Task<IActionResult> Add(Place place)
    {
        try
        {
            await _placeService.Insert(place);
            return Ok(place);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // controller which updates a place in the database
    [HttpPut]
    public async Task<IActionResult> Update(Place place)
    {
        try
        {
            await _placeService.Update(place);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // controller which deletes a place from the database
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _placeService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}