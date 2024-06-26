using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class FavoritePlaceService : CRUDService<FavoritePlace>, IFavoritePlaceService
    {

        public FavoritePlaceService(IRepository<FavoritePlace> favoritePlaceRepository) : base(favoritePlaceRepository) { }

        // <inheritdoc />
        public async Task<FavoritePlaceDtoUp> GetFavoritePlacesById(int id)
        {
            try
            {
                var favoritePlaceModel = await Get(f => f.Id == id);

                if (favoritePlaceModel == null)
                {
                    throw new Exception("Error - Favorite place doesn't exist.");
                }

                var favoritePlace = new FavoritePlaceDtoUp()
                {
                    Id = favoritePlaceModel.Id.Value,
                    Latitude = favoritePlaceModel.Latitude,
                    Longitude = favoritePlaceModel.Longitude,
                    Altitude = favoritePlaceModel.Altitude,
                    Title = favoritePlaceModel.Title,
                    City = favoritePlaceModel.City,
                    PostalCode = favoritePlaceModel.PostalCode,
                    Adress = favoritePlaceModel.Adress,
                    Name = favoritePlaceModel.Name,
                    UserId = favoritePlaceModel.IdUser
                };

                return favoritePlace;
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not get favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public async Task<List<FavoritePlaceDtoUp>> GetFavoritePlacesByUser(int idUser)
        {
            try
            {
                var favoritePlacesList = await GetAll(p => p.IdUser == idUser, orderBy: p => p.OrderBy(p => p.Title));
                var favoritePlaces = favoritePlacesList.ToList();

                if (favoritePlaces is null)
                {
                    throw new Exception("Error - No favorite places found for this user.");
                }

                var listFavoritePlaces = favoritePlaces.Select(fav => new FavoritePlaceDtoUp()
                {
                    Id = fav.Id.Value,
                    Latitude = fav.Latitude,
                    Longitude = fav.Longitude,
                    Altitude = fav.Altitude,
                    Title = fav.Title,
                    City = fav.City,
                    PostalCode = fav.PostalCode,
                    Adress = fav.Adress,
                    Name = fav.Name,
                    UserId = fav.IdUser
                }).ToList();

                return listFavoritePlaces;
            }
                        catch (Exception e)
            {
                throw new Exception("Error - Could not get favorite places: " + e.Message);
            }
        }

        // <inheritdoc />
        public async Task InsertFavoritePlaces(FavoritePlaceRegisterDtoDown favoritePlace)
        {
            try
            {
                var favoritePlaceModel = new FavoritePlace()
                {
                    Latitude = favoritePlace.Latitude,
                    Longitude = favoritePlace.Longitude,
                    Altitude = favoritePlace.Altitude,
                    Title = favoritePlace.Title,
                    City = favoritePlace.City,
                    PostalCode = favoritePlace.PostalCode,
                    Adress = favoritePlace.Adress,
                    Name = favoritePlace.Name,
                    IdUser = favoritePlace.UserId
                };

                await Insert(favoritePlaceModel);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert favorite place: " + e.Message);
            }
        }

        // <inheritdoc />
        public async Task UpdateFavoritePlace(FavoritePlaceUpdateDtoDown favoritePlace)
        {
            try
            {
                var favoritePlaceModel = new FavoritePlace()
                {
                    Id = favoritePlace.Id,
                    Latitude = favoritePlace.Latitude,
                    Longitude = favoritePlace.Longitude,
                    Altitude = favoritePlace.Altitude,
                    Title = favoritePlace.Title,
                    City = favoritePlace.City,
                    PostalCode = favoritePlace.PostalCode,
                    Adress = favoritePlace.Adress,
                    Name = favoritePlace.Name,
                    IdUser = favoritePlace.UserId
                };

                await Update(favoritePlaceModel);
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
                var favoritePlace = await Get(f => f.Id == id);

                if (favoritePlace == null)
                {
                    throw new Exception("Error - Favorite place doesn't exist.");
                }
                await Delete(favoritePlace);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete favorite place: " + e.Message);
            }
        }
    }
}
