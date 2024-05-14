using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.DAL.Contracts.Models
{
    public interface IFavoritePlaceRepository: IRepository<FavoritePlace>
    {
        /// <summary>
        /// Gets FavoritePlaces by user.
        /// </summary>
        /// <param name="userId">User of the user we want the favorite places. </param>
        /// <returns>Returns a list of <see cref="FavoritePlace"/>.</returns>
        public Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId);

    }
}
