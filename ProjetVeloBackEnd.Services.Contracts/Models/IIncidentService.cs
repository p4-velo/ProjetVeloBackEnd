using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IIncidentService
    {
        /// <summary>
        /// Gets an idIncident by its id.
        /// </summary>
        /// <param name="id"> Id of the idIncident we want.</param>
        /// <returns>Returns the idIncident asked.</returns>
        public Task<Incident> GetIncidentById(int id);

        /// <summary>
        /// Gets all active incidents ( < 5 count ).
        /// </summary>
        /// <returns>Returns a list of active incidents.</returns>
        public Task<List<Incident>> GetActiveIncidents();

        /// <summary>
        /// Gets all inactive incidents ( > 5 count ).
        /// </summary>
        /// <returns>Returns a list of inactive incidents.</returns>
        public Task<List<Incident>> GetInactiveIncidents();

        /// <summary>
        /// Adds an idIncident to the database.
        /// </summary>
        /// <param name="incident">Entities we want to save in database.</param>
        public Task AddIncident(Incident incident);

        /// <summary>
        /// Updates an idIncident in the database.
        /// </summary>
        /// <param name="idIncident">Id of the entity to update.</param>
        public Task IncrementCountIncident(int idIncident);
    }
}
