using ProjetVeloBackEnd.DAL.Contracts.IRepositories;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class FavoritePlaceService :  IFavoritePlaceService
    {
        private readonly IFavoritePlaceRepository _favoritePlaceRepository;

        public FavoritePlaceService(IFavoritePlaceRepository favoritePlaceRepository) { 
            _favoritePlaceRepository = favoritePlaceRepository;
        }

        public async Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId)
        {
           var listeFavorites = await _favoritePlaceRepository.GetFavoritePlacesByUser(userId);
            if (listeFavorites == null)
            {
                throw new Exception("Error - No data");
            }

            return listeFavorites;
        }
    }
}
