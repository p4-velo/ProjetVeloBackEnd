using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class IncidentService : CRUDService<Incident>, IIncidentService
    {

        public IncidentService(IRepository<Incident> incidentRepository): base(incidentRepository) {}

        public async Task<IncidentDtoUp> GetIncidentById(int id)
        {
            var incidentModel = await this.Get(f => f.Id == id);

            if (incidentModel == null)
            {
                throw new Exception("Error - Incident doesn't exist.");
            }

            var incident = new IncidentDtoUp()
            {
                Id = incidentModel.Id.Value,
                Latitude = incidentModel.Latitude,
                Longitude = incidentModel.Longitude,
                Altitude = incidentModel.Altitude,
                IncidentType = incidentModel.IncidentType
            };

            return incident;
        }

        public async Task<List<IncidentDtoUp>> GetActiveIncidents()
        {
            var incidentsListModel = await this.GetAll(p => p.CountFinished < 5);
            var incidentsModel = incidentsListModel.ToList();

            if (incidentsModel == null)
            {
                throw new Exception("Error - No active incidents found.");
            }

            var incidents = incidentsModel.Select(incidentModel => new IncidentDtoUp()
            {
                Id = incidentModel.Id.Value,
                Latitude = incidentModel.Latitude,
                Longitude = incidentModel.Longitude,
                Altitude = incidentModel.Altitude,
                IncidentType = incidentModel.IncidentType
            }).ToList();    

            return incidents;
        }

        public async Task<List<IncidentDtoUp>> GetInactiveIncidents()
        {
            var incidentsListModel = await this.GetAll(p => p.CountFinished >= 5);
            var incidentsModel = incidentsListModel.ToList();

            if (incidentsModel == null)
            {
                throw new Exception("Error - No inactive incidents found.");
            }

            var incidents = incidentsModel.Select(incidentModel => new IncidentDtoUp()
            {
                Id = incidentModel.Id.Value,
                Latitude = incidentModel.Latitude,
                Longitude = incidentModel.Longitude,
                Altitude = incidentModel.Altitude,
                IncidentType = incidentModel.IncidentType
            }).ToList();

            return incidents;
        }

        public async Task AddIncident(IncidentRegisterDtoDown incident)
        {
            try
            {
                var incidentModel = new Incident
                {
                    Latitude = incident.Latitude,
                    Longitude = incident.Longitude,
                    Altitude = incident.Altitude,
                    IncidentType = incident.IncidentType,
                    CountFinished = 0
                };

                await this.Insert(incidentModel);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert incidentModel: " + e.Message);
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
                throw new Exception("Error - Could not update incidentModel: " + e.Message);
            }
        }
    }
}
