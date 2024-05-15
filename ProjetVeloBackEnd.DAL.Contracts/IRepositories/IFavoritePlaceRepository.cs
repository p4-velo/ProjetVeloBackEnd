using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.DAL.Contracts.IRepositories
{
    public interface IFavoritePlaceRepository
    {
        /// <summary>
        /// Gets FavoritePlaces by user.
        /// </summary>
        /// <param name="userId">User of the user we want the favorite places. </param>
        /// <returns>Returns a list of <see cref="FavoritePlace"/>.</returns>
        public Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId);

    }
}
