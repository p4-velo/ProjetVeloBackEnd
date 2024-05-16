using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class FavoritePlaceService : IFavoritePlaceService
    {
        private readonly ICRUDService<FavoritePlace> _favoritePlaceService;

        public FavoritePlaceService(ICRUDService<FavoritePlace> favoritePlaceService)
        {
            _favoritePlaceService = favoritePlaceService;
        }

        // <inheritdoc />
        public FavoritePlace GetFavoritePlacesById(int id)
        {
            var favoritePlace = _favoritePlaceService.Get(f => f.Id == id).Result ;

            if (favoritePlace == null)
            {
                throw new Exception("Error - Favorite place doesn't exist.");
            }

            return favoritePlace;
        }

        // <inheritdoc />
        public List<FavoritePlace> GetFavoritePlacesByUser(int idUser)
        {
            var favoritePlacesList = _favoritePlaceService.GetAll(p => p.IdUser == idUser, orderBy: p => p.OrderBy(p => p.Name));
            var favoritePlaces = favoritePlacesList.Result.ToList();

            if (favoritePlaces != null)
            {
                throw new Exception("Error - No favorite places found for this user.");
            }

            return favoritePlaces;
        }

        // <inheritdoc />
        public void InsertFavoritePlaces(FavoritePlace favoritePlace)
        {
            try
            {
                _favoritePlaceService.Insert(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public void UpdateFavoritePlace(FavoritePlace favoritePlace)
        {
            try
            {
                _favoritePlaceService.Update(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not update favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public void DeleteFavoritePlace(int id)
        {
            try
            {
                var favoritePlace = GetFavoritePlacesById(id);
                _favoritePlaceService.Delete(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete favorite place: " + e.Message);
            }
        }
    }
}
