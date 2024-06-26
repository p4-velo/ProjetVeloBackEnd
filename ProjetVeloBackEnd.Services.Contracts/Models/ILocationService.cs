﻿using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets a location by its position (latitude x, longitude y).
        /// </summary>
        /// <param name="latitude">Latitude (x).</param>
        /// <param name="longitude">Longitude (y).</param>
        /// <returns>Return a location.</returns>
        public Task<Location> GetLocationByLongLat ( string latitude, string longitude);

        /// <summary>
        /// Gets a location by its id.
        /// </summary>
        /// <param name="id">Identifiant of the location.</param>
        /// <returns>Return a location.</returns>
        public Task<Location> GetLocationById(int id);

        /// <summary>
        /// Adds a location to the database.
        /// </summary>
        /// <param name="location">Modèle de type <see cref="Location"/> à enregistrer.</param>
        public Task InsertLocation(Location location);

        /// <summary>
        /// Deletes a location from the database.
        /// </summary>
        /// <param name="latitude">Latitude (x).</param>
        /// <param name="longitude">Longitude (y).</param>
        public Task DeleteLocationByLongLat(string latitude, string longitude);

        /// <summary>
        /// Deletes a location from the database.
        /// </summary>
        /// <param name="id">Identifiant of the location to delete.</param>
        public Task DeleteLocationById(int id);
    }
}
