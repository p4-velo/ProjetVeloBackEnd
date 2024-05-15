using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IFavoritePlaceService
    {
        /// <summary>
        /// Gets FavoritePlaces by user.
        /// </summary>
        /// <param name="userId">User Id whom you want the favorites.</param>
        /// <returns>Return a Task of <see cref="FavoritePlace"/> in a List.</returns>
        public Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId);
    }
}
