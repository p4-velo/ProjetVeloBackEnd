using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IFavoritePlaceService
    {
        public Task<List<FavoritePlace>> GetFavoritePlacesByUser(int userId);
    }
}
