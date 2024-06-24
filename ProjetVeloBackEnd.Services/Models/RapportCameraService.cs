using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Entities;
using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using ProjetVeloBackEnd.Services.Contracts.Models;

namespace ProjetVeloBackEnd.Services.Models
{
    public class RapportCameraService : CRUDService<RapportCamera>, IRapportCamera
    {

        public RapportCameraService(IRepository<RapportCamera> repository) : base(repository) { }

        public async Task<List<RapportCameraDtoUp>> GetRapportCameraByIdCamera(int idCamera)
        {
            try
            {
                var rapportCameraList = await GetAll(p => p.IdCamera == idCamera, orderBy: p => p.OrderBy(p => p.Date));
                var rapportCameras = rapportCameraList.ToList();

                if (rapportCameras is null)
                {
                    throw new Exception("Error - No rapport camera found for this camera.");
                }

                var listRapportCameras = rapportCameras.Select(rap => new RapportCameraDtoUp()
                {
                    Id = rap.Id,
                    IdCamera = rap.IdCamera,
                    NombrePlace = rap.NombrePlace,
                    NombreVelos = rap.NombreVelos,
                    Date = rap.Date
                }).ToList();

                return listRapportCameras;
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not get rapport camera: " + e.Message);
            }
        }
       
        public async Task InsertRapportCamera(RapportCameraRegisterDtoDown rapportCamera)
        {
            try
            {
                var rapportCameraModel = new RapportCamera
                {
                    IdCamera = rapportCamera.IdCamera,
                    NombrePlace = rapportCamera.NombrePlace,
                    NombreVelos = rapportCamera.NombreVelos,
                    Date = rapportCamera.Date
                };

                await Insert(rapportCameraModel);
            }
            catch (Exception e)
            {
                throw new Exception("Error - Could not insert rapportCamera: " + e.Message);
            }
        }
    }
}
