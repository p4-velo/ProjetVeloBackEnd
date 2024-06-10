using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Up
{
    public class VeloParkDtoUp
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Icon { get; set; }

        public required VeloParkType VeloParkType { get; set; }
    }
}
