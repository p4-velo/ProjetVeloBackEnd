using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class IncidentService : IIncidentService
    {
        private readonly ICRUDService<Incident> _incidentService;

        public IncidentService(ICRUDService<Incident> incidentService)
        {
            _incidentService = incidentService;
        }

        public Incident GetIncidentById(int id)
        {
            var incident = _incidentService.Get(f => f.Id == id).Result;

            if (incident == null)
            {
                throw new Exception("Error - Incident doesn't exist.");
            }

            return incident;
        }

        public List<Incident> GetActiveIncidents()
        {
            var incidentsList = _incidentService.GetAll(p => p.CountFinished < 5);
            var incidents = incidentsList.Result.ToList();

            if (incidents == null)
            {
                throw new Exception("Error - No active incidents found.");
            }

            return incidents;
        }

        public List<Incident> GetInactiveIncidents()
        {
            var incidentsList = _incidentService.GetAll(p => p.CountFinished >= 5);
            var incidents = incidentsList.Result.ToList();

            if (incidents == null)
            {
                throw new Exception("Error - No inactive incidents found.");
            }

            return incidents;
        }

        public void AddIncident(Incident incident)
        {
            try
            {
                _incidentService.Insert(incident);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert incident: " + e.Message);
            }
        }

        public void IncrementCountIncident(int idIncident)
        {
            try
            {
                var incident = _incidentService.Get(f => f.Id == idIncident).Result;
                incident.CountFinished++;
                _incidentService.Update(incident);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not update incident: " + e.Message);
            }
        }
    }
}
