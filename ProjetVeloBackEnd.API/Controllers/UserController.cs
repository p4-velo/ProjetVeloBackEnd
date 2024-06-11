using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;

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

}

