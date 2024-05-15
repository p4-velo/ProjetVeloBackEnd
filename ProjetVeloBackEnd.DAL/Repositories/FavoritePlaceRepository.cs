using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.DAL.Contracts.IRepositories;
using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.DAL.Repositories
{
    public class FavoritePlaceRepository: IFavoritePlaceRepository
    {
        private readonly IRepository<FavoritePlace> _repository;
        public FavoritePlaceRepository(IRepository<FavoritePlace> repository)
        {
            _repository = repository;
        }

        // <inheritdoc/>
        public async Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId)
        {
            try
            {
                var allUsers = await _repository.GetAll().Result.Where(x => x.Users.Id == userId, false).ToList();
                var userFavorites = allUsers.Where(x => x.Users.Id == userId).ToList();

                return userFavorites;
            }
            catch (Exception e)
            {
                throw new Exception("Error - Fail to access data", e);
            }
        }
    }
}
