using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.DAL.Models;

public class PlaceService : CRUDService<Place>, IPLaceService
{
    public PlaceService(IRepository<Place> repository) : base(repository) { }
}