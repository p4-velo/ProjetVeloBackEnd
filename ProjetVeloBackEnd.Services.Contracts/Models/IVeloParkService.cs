using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IVeloParkService
    {
        Task<List<VeloParkDtoUp>> GetAll();

        Task<VeloParkDtoUp> GetById(int id);

        Task Insert(VeloParkRegisterDtoDown VeloParkDto);

        Task Update(VeloParkUpdateDtoDown veloParkDto);

        Task UpdateIncrementRemainingPlaces(int id);

        Task UpdateDecrementRemainingPlaces(int id);

        Task Delete(int id);
    }
}
