using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.DAL.Contracts.Models;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class FavoritePlaceService : CRUDService<FavoritePlace>, IFavoritePlaceService
    {
        private readonly IRepository<FavoritePlace> _repository;
        private readonly IFavoritePlaceRepository _favoritePlaceRepository;

        public FavoritePlaceService(IRepository<FavoritePlace> repository, IFavoritePlaceRepository favoritePlaceRepository) : base(repository) { 
            _repository = repository;
            _favoritePlaceRepository = favoritePlaceRepository;
        }

        public async Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId)
        {
           return await _favoritePlaceRepository.GetFavoritePlacesByUser(userId);
        }
    }
}
