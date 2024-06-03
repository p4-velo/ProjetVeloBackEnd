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
    public class LocationService : ILocationService
    {
        private readonly ICRUDService<Location> _locationService;

        public LocationService(ICRUDService<Location> locationService)
        {
            _locationService = locationService;
        }

        public Location GetLocationByLongLat(string latitude, string longitude)
        {
            try
            {
                if (latitude == null || latitude == "" && longitude == null || longitude == "")
                {
                    throw new Exception("Error - Given latitude or longitude is null or empty.");
                }

                var lat = _locationService.GetAll(l => l.Latitude == latitude).Result;
                var lon = _locationService.GetAll(l => l.Longitude == longitude).Result;

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

        public Location GetLocationById(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Error - Given id is null.");
                }

                var location = _locationService.Get(l => l.Id == id).Result;

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

        public void InsertLocation(Location location)
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

                _locationService.Insert(location);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert location: " + e.Message);
            }
        }

        public void DeleteLocationByLongLat(string latitude, string longitude)
        {
            try
            {
                if (latitude == null || latitude == "" && longitude == null || longitude == "")
                {
                    throw new Exception("Error - Given latitude or longitude is null or empty.");
                }

                var lat = _locationService.GetAll(l => l.Latitude == latitude).Result;
                var lon = _locationService.GetAll(l => l.Longitude == longitude).Result;

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

                _locationService.Delete(inter.FirstOrDefault());
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete location: " + e.Message);
            }
        }

        public void DeleteLocationById(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Error - Given id is null.");
                }

                var location = _locationService.Get(l => l.Id == id).Result;

                if (location == null)
                {
                    throw new Exception("Error - Location not found.");
                }

                _locationService.Delete(location);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not delete location: " + e.Message);
            }
        }
    }
}