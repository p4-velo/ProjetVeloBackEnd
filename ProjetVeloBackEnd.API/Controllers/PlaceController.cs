using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using System;


namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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

}