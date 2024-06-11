using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class RapportCameraController : Controller
{
    private readonly IRapportCamera _rapportCameraService;

    public RapportCameraController(IRapportCamera rapportCameraService)
    {
        _rapportCameraService = rapportCameraService;
    }

    [HttpGet("{id}")]
    public async Task<IList<RapportCameraDtoUp>> GetAllByIdCamera(int id)
    {
        return await _rapportCameraService.GetRapportCameraByIdCamera(id);
    }

    [HttpPost]
    public async Task<IActionResult> Insert(RapportCameraRegisterDtoDown rapportCameraDtoUp)
    {
        await _rapportCameraService.InsertRapportCamera(rapportCameraDtoUp);
        return Ok();
    }
}
