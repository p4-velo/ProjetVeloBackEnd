using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using System;


namespace projet_velo_back_end.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class UserController : Controller
{
    private readonly ICRUDService<User> _userService;

    public UserController(ICRUDService<User> userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> Add(User user)
    {
        try
        {
            // Si vous avez besoin de gérer les FavoritePlaces, vous pouvez le faire ici avant d'insérer l'utilisateur
            if (user.FavoritePlaces != null)
            {
                foreach (var favoritePlace in user.FavoritePlaces)
                {
                    favoritePlace.IdUser = user.Id; // Associez l'utilisateur à chaque FavoritePlace
                }
            }

            await _userService.Insert(user);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}

