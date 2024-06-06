using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;


namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class FavoritePlaceController : Controller
{
    private readonly IFavoritePlaceService _favoritePlaceService;

    public FavoritePlaceController(IFavoritePlaceService favoritePlaceService)
    {
        _favoritePlaceService = favoritePlaceService;
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
            var favoritePlace = _favoritePlaceService.GetFavoritePlacesById(id);
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
    /// <param name="idUser">Id of the user whom you want favorites of.</param>
    /// <returns>Returns a status code 200 and the asked favorite places for the user in case of success
    /// or status code 400 in case of failure.</returns>
    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetFavoritePlacesByUser(int id)
    {
        try
        {
            var listFavoritePlaces = _favoritePlaceService.GetFavoritePlacesByUser(id);
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
            _favoritePlaceService.InsertFavoritePlaces(favoritePlace);
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
            _favoritePlaceService.UpdateFavoritePlace(favoritePlace);
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
            _favoritePlaceService.DeleteFavoritePlace(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
