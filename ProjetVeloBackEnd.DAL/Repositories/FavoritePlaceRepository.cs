using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.DAL.Models
{
    public class FavoritePlaceService
    {
        private readonly IRepository<FavoritePlace> _repository;
        public FavoritePlaceService(IRepository<FavoritePlace> repository) {
            _repository = repository;
        }

        // <inheritdoc/>
        public async Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId)
        {
            var allUsers = await _repository.GetAll();
            return allUsers.Where(x => x.Users.Id == userId).ToList();
        }
    }
}
