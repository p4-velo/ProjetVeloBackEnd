using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using System;


namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class FavoritePlaceController : Controller
{
    private readonly ICRUDService<FavoritePlace> _favoritePlaceService;

    public FavoritePlaceController(ICRUDService<FavoritePlace> favoritePlaceService)
    {
        _favoritePlaceService = favoritePlaceService;
    }

    // controller which displays all favorite places in the database
    [HttpGet("{userId}")]
    public async Task<IList<FavoritePlace>> GetAll(int userId)
    {
        return await _favoritePlaceService.GetAll(fp => fp.idUser == userId);
    }

    // controller which displays a favorite place by user id
    /*[HttpGet("{id}")]
    public async Task<FavoritePlace?> Get(int id)
    {
        return await _favoritePlaceService.Get(p => p.idUser == id);
    }*/




    // controller which adds a favorite place to the database
    [HttpPost]
    public async Task<IActionResult> Add(FavoritePlace favoritePlace)
    {
        try
        {
            await _favoritePlaceService.Insert(favoritePlace);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
