using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class VeloParkService : IVeloParkService
    {
        public Task Delete(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception("Error - Could not delete Velo park: " + ex.Message);
            }
        }

        public Task<List<VeloParkDtoUp>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<VeloParkDtoUp> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(VeloParkRegisterDtoDown VeloParkDto)
        {
            throw new NotImplementedException();
        }

        public Task Update(VeloParkUpdateDtoDown veloParkDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDecrementRemainingPlaces(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIncrementRemainingPlaces(int id)
        {
            throw new NotImplementedException();
        }
    }
}
