using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models;
public class PlaceService : CRUDService<Place>, IPLaceService
{
    public PlaceService(IRepository<Place> repository) : base(repository) { }

    public async Task DeletePlace(int id)
    {
        try
        {
            var placeModel = await Get(p => p.Id == id);

            if (placeModel == null)
            {
                throw new Exception("Error - Place doesn't exist.");
            }

            await Delete(placeModel);
        }
        catch (Exception e)
        {
            throw new Exception("Error - Could not delete place: " + e.Message);
        }
    }

    public async Task<PlaceDtoUp> GetPlacesById(int id)
    {
        try
        {
            var placeModel = await Get(f => f.Id == id);

            if (placeModel == null)
            {
                throw new Exception("Error - Place doesn't exist.");
            }

            var place = new PlaceDtoUp()
            {
                Id = placeModel.Id,
                Latitude = placeModel.Latitude,
                Longitude = placeModel.Longitude,
                Altitude = placeModel.Altitude,
                City = placeModel.City,
                PostalCode = placeModel.PostalCode,
                Adress = placeModel.Adress,
                Name = placeModel.Name
            };

            return place;
        }
        catch (Exception e)
        {
            throw new Exception("Error - Could not get place: " + e.Message);
        }
    }

    public async Task InsertPlaces(PlaceRegisterDtoDown place)
    {
        try
        {
            var placeModel = new Place()
            {
                City = place.City,
                PostalCode = place.PostalCode,
                Adress = place.Adress,
                Name = place.Name,
                Longitude = place.Longitude,
                Latitude = place.Latitude,
                Altitude = place.Altitude
            };

            await Insert(placeModel);
        }
        catch (Exception e)
        {
            throw new Exception("Error - Could not insert place: " + e.Message);
        }
    }

    public async Task UpdatePlace(PlaceUpdateDtoDown place)
    {
        try
        {
            var placeModel = new Place()
            {
                Id = place.Id,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                Altitude = place.Altitude,
                City = place.City,
                PostalCode = place.PostalCode,
                Adress = place.Adress,
                Name = place.Name,
            };

            await Update(placeModel);
        }
        catch (Exception e)
        {
            throw new Exception("Error - Could not update place: " + e.Message);
        }
    }
}