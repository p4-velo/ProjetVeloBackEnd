using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class IncidentService : CRUDService<Incident>, IIncidentService
    {

        public IncidentService(IRepository<Incident> incidentRepository): base(incidentRepository) {}

        public async Task<Incident> GetIncidentById(int id)
        {
            var incident = await this.Get(f => f.Id == id);

            if (incident == null)
            {
                throw new Exception("Error - Incident doesn't exist.");
            }

            return incident;
        }

        public async Task<List<Incident>> GetActiveIncidents()
        {
            var incidentsList = await this.GetAll(p => p.CountFinished < 5);
            var incidents = incidentsList.ToList();

            if (incidents == null)
            {
                throw new Exception("Error - No active incidents found.");
            }

            return incidents;
        }

        public async Task<List<Incident>> GetInactiveIncidents()
        {
            var incidentsList = await this.GetAll(p => p.CountFinished >= 5);
            var incidents = incidentsList.ToList();

            if (incidents == null)
            {
                throw new Exception("Error - No inactive incidents found.");
            }

            return incidents;
        }

        public async Task AddIncident(Incident incident)
        {
            try
            {
                await this.Insert(incident);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert incident: " + e.Message);
            }
        }

        public async Task IncrementCountIncident(int idIncident)
        {
            try
            {
                var incident = await this.Get(f => f.Id == idIncident);
                incident.CountFinished++;
                await this.Update(incident);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not update incident: " + e.Message);
            }
        }
    }
}
