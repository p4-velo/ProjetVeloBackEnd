using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.DAL.Models;

public class PlaceRepository : CRUDService<Place>, IPLaceService
{
    public PlaceRepository(IRepository<Place> repository) : base(repository) { }
}