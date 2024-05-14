using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models;
public class PlaceService : CRUDService<Place>, IPlaceService
{
    public PlaceService(IRepository<Place> repository) : base(repository) { }
}