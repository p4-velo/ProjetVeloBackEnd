using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IPLaceService
    {
        /// <summary>
        /// Gets a place by its id.
        /// </summary>
        /// <param name="id">Id of the item we want.</param>
        /// <returns>Return a <see cref="PlaceDtoUp"/> entities.</returns>
        public Task<PlaceDtoUp> GetPlacesById(int id);

        /// <summary>
        /// Inserts a place in the database.
        /// </summary>
        /// <param name="place">Entities you want to register.</param>
        public Task InsertPlaces(PlaceRegisterDtoDown place);

        /// <summary>
        /// Updates a place in the database.
        /// </summary>
        /// <param name="place">Entities that will overwrite database's object.</param>
        public Task UpdatePlace(PlaceUpdateDtoDown place);

        /// <summary>
        /// Deletes a place in the database.
        /// </summary>
        /// <param name="id">Id of the item we want to delete.</param>
        public Task DeletePlace(int id);
    }
}