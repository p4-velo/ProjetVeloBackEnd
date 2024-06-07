using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Down
{
    public class IncidentRegisterDtoDown
    {
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required string Altitude { get; set; }
        public required IncidentType IncidentType { get; set; }
    }
}
