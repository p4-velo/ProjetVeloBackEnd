using Microsoft.AspNetCore.Mvc;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class FavoritePlaceController : Controller
    {
        private readonly ICRUDService<FavoritePlace> _favoritePlaceService;
        private readonly IFavoritePlaceService _favoritePlaceAppService;

        public FavoritePlaceController(ICRUDService<FavoritePlace> favoritePlaceService, IFavoritePlaceService favoritePlaceAppService)
        {
            _favoritePlaceService = favoritePlaceService;
            _favoritePlaceAppService = favoritePlaceAppService;
        }

        // Gets a favourite place by its id.
        [HttpGet]
        [Route("{id}")]
        public async Task<FavoritePlace> GetById(int id)
        {
            var favorite =  await _favoritePlaceService.Get(x => x.Id == id);

            if (favorite == null)
            {
                throw new Exception("Error - No data");
            }

            return favorite;
        }

        // Gets a place for a user.
        [HttpGet]
        [Route("user/{idUser}")]
        public async Task<List<FavoritePlace>> GetByUser(int idUser)
        {
            return await _favoritePlaceAppService.GetFavoritePlacesByUser(idUser);
        }

        // Adds a place to the user's favourites.
        [HttpPost]
        public async Task<IActionResult> AddFavoritePlace([FromBody] FavoritePlace favoritePlace)
        {
            await _favoritePlaceService.Insert(favoritePlace);
            return Ok();
        }

        // Deletes a place from the user's favourites.
        [HttpDelete("{id}")]
        public async Task DeleteFavoritePlace(int id)
        {
            await _favoritePlaceService.Delete(id);
        }

        // Updates a place in the user's favourites.
        [HttpPut]
        public async Task UpdateFavoritePlace([FromBody] FavoritePlace favoritePlace)
        {
            await _favoritePlaceService.Update(favoritePlace);
        }
    }
}
