using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Services.Models
{
    public class LocationService : CRUDService<Location>, ILocationService
    {

        public LocationService(IRepository<Location> locationRepository) : base(locationRepository){}

        public async Task<Location> GetLocationByLongLat(string latitude, string longitude)
        {
            try
            {
                if (latitude == null || latitude == "" && longitude == null || longitude == "")
                {
                    throw new Exception("Error - Given latitude or longitude is null or empty.");
                }

                var lat = await this.GetAll(l => l.Latitude == latitude);
                var lon = await this.GetAll(l => l.Longitude == longitude);

                if (lat == null)
                {
                    throw new Exception("Error - Latitude not found.");
                }
                else if (lon == null)
                {
                    throw new Exception("Error - Longitude not found.");
                }

                var inter = lat.Intersect(lon).ToList();

                if (!inter.Any())
                {
                    throw new Exception("Error - Location not found.");
                }

                return inter.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not get location: " + e.Message);
            }
        }

        public async Task<Location> GetLocationById(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Error - Given id is null.");
                }

                var location = this.Get(l => l.Id == id).Result;

                if (location == null)
                {
                    throw new Exception("Error - Location not found.");
                }

                return location;
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not get location: " + e.Message);
            }
        }

        public async Task InsertLocation(Location location)
        {
            try
            {
                if(location == null)
                {
                    throw new Exception("Error - Location is null.");
                }

                if(location.Latitude == null || location.Latitude == "" && location.Longitude == null || location.Longitude == "")
                {
                    throw new Exception("Error - Given latitude or longitude is null or empty.");
                }

                await this.Insert(location);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert location: " + e.Message);
            }
        }

        public async Task DeleteLocationByLongLat(string latitude, string longitude)
        {
            try
            {
                if (latitude == null || latitude == "" && longitude == null || longitude == "")
                {
                    throw new Exception("Error - Given latitude or longitude is null or empty.");
                }

                var lat = await this.GetAll(l => l.Latitude == latitude);
                var lon = await this.GetAll(l => l.Longitude == longitude);

                if (lat == null)
                {
                    throw new Exception("Error - Latitude not found.");
                }
                else if (lon == null)
                {
                    throw new Exception("Error - Longitude not found.");
                }

                var inter = lat.Intersect(lon).ToList();

                if (!inter.Any())
                {
                    throw new Exception("Error - Location not found.");
                }

                await this.Delete(inter.FirstOrDefault());
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete location: " + e.Message);
            }
        }

        public async Task DeleteLocationById(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Error - Given id is null.");
                }

                var location = await this.Get(l => l.Id == id);

                if (location == null)
                {
                    throw new Exception("Error - Location not found.");
                }

                await this.Delete(location);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete location: " + e.Message);
            }
        }
    }
}