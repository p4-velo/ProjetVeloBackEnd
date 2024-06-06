using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;


namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class FavoritePlaceController : Controller
{
    private readonly IFavoritePlaceService _favoritePlaceService;
    private readonly ICRUDService<FavoritePlace> cRUDService;
    public FavoritePlaceController(IFavoritePlaceService favoritePlaceService, ICRUDService<FavoritePlace> cRUD)
    {
        _favoritePlaceService = favoritePlaceService;
        cRUDService = cRUD;
    }

    [HttpGet]
    public async Task<IList<FavoritePlace>> GetAll()
    {
        return await cRUDService.GetAll();
    }

    /// <summary>
    /// Gets a favorite place by its id.
    /// </summary>
    /// <param name="id"> Id of the favorite place we want.</param>
    /// <returns>Returns a status code 200 and the asked favorite place in case of success or status code 400 in case of failure.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFavoritePlaceById(int id)
    {
        try
        {
            var favoritePlace = await _favoritePlaceService.GetFavoritePlacesById(id);
            return Ok(favoritePlace);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Gets all favorite places by user.
    /// </summary>
    /// <param name="id">Id of the user whom you want favorites of.</param>
    /// <returns>Returns a status code 200 and the asked favorite places for the user in case of success
    /// or status code 400 in case of failure.</returns>
    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetFavoritePlacesByUser(int id)
    {
        try
        {
            var listFavoritePlaces = await _favoritePlaceService.GetFavoritePlacesByUser(id);
            return Ok(listFavoritePlaces);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Adds a favorite place to the database.
    /// </summary>
    /// <param name="favoritePlace">Entities we want to save in database.</param>
    /// <returns>Returns a status code 200 in case of success or status code 400 in case of failure.</returns>
    [HttpPost]
    public async Task<IActionResult> AddFavoritePlace(FavoritePlace favoritePlace)
    {
        try
        {
            await _favoritePlaceService.InsertFavoritePlaces(favoritePlace);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Updates a favorite place in database.
    /// </summary>
    /// <param name="favoritePlace">Entities we want to modify in database.</param>
    /// <returns>Returns a status code 200 in case of success or status code 400 in case of failure.</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateFavoritePlace(FavoritePlace favoritePlace)
    {
        try
        {
            await _favoritePlaceService.UpdateFavoritePlace(favoritePlace);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Deletes a favorite place in database.
    /// </summary>
    /// <param name="id">Id of the favorite place we want to delete.</param>
    /// <returns>Returns a status code 200 in case of success or status code 400 in case of failure.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFavoritePlace(int id)
    {
        try
        {
            await _favoritePlaceService.DeleteFavoritePlace(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
