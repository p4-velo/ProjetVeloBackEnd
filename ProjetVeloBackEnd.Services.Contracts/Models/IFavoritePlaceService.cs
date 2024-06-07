using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IFavoritePlaceService
    {
        /// <summary>
        /// Gets a favorite place by its id.
        /// </summary>
        /// <param name="id">Id of the favorite item we want.</param>
        /// <returns>Return a <see cref="FavoritePlace"/> entities.</returns>
        public Task<FavoritePlaceDtoUp> GetFavoritePlacesById(int id);

        /// <summary>
        /// Gets all favorite places by user.
        /// </summary>
        /// <param name="idUser">Id of the user whom you want favorite places of.</param>
        /// <returns>Return a <see cref="FavoritePlace"/> list based on the users favorites.</returns>
        public Task<List<FavoritePlaceDtoUp>> GetFavoritePlacesByUser(int idUser);

        /// <summary>
        /// Inserts a favorite place in the database.
        /// </summary>
        /// <param name="favoritePlace">Entities you want to register.</param>
        public Task InsertFavoritePlaces(FavoritePlaceRegisterDtoDown favoritePlace);

        /// <summary>
        /// Updates a favorite place in the database.
        /// </summary>
        /// <param name="favoritePlace">Entities that will overwrite database's object.</param>
        public Task UpdateFavoritePlace(FavoritePlaceUpdateDtoDown favoritePlace);

        /// <summary>
        /// Deletes a favorite place in the database.
        /// </summary>
        /// <param name="id">Id of the favorite item we want to delete.</param>
        public Task DeleteFavoritePlace(int id);
    }
}
