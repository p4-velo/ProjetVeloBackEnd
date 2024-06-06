using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class FavoritePlaceService : CRUDService<FavoritePlace>, IFavoritePlaceService
    {
 
        public FavoritePlaceService(IRepository<FavoritePlace> favoritePlaceRepository) : base(favoritePlaceRepository){}

        // <inheritdoc />
        public async Task<FavoritePlace> GetFavoritePlacesById(int id)
        {
            var favoritePlace = await Get(f => f.Id == id) ;

            if (favoritePlace == null)
            {
                throw new Exception("Error - Favorite place doesn't exist.");
            }

            return favoritePlace;
        }

        // <inheritdoc />
        public async Task<List<FavoritePlace>> GetFavoritePlacesByUser(int idUser)
        {
            
            var favoritePlacesList = await GetAll(p => p.idUser == idUser, orderBy: p => p.OrderBy(p => p.Name));
            var favoritePlaces = favoritePlacesList.ToList();

            if (favoritePlaces != null)
            {
                throw new Exception("Error - No favorite places found for this user.");
            }
            else
            {
                return favoritePlaces;
            }
           
        }

        // <inheritdoc />
        public async Task InsertFavoritePlaces(FavoritePlace favoritePlace)
        {
            try
            {
                await Insert(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public async Task UpdateFavoritePlace(FavoritePlace favoritePlace)
        {
            try
            {
                await Update(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not update favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public async Task DeleteFavoritePlace(int id)
        {
            try
            {
                var favoritePlace = await GetFavoritePlacesById(id);
                await Delete(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete favorite place: " + e.Message);
            }
        }
    }
}
