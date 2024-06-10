using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Down
{
    public class VeloParkUpdateDtoDown
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Icon { get; set; }

        public required VeloParkType VeloParkType { get; set; }
    }
}
