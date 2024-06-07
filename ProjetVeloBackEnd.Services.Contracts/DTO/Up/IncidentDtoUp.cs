using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Up
{
    public class IncidentDtoUp
    {
        public required int Id { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required string Altitude { get; set; }
        public required IncidentType IncidentType { get; set; }
    }
}
