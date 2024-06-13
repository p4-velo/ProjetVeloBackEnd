using ProjetVeloBackEnd.Services.Contracts.DTO.Down;
using ProjetVeloBackEnd.Services.Contracts.DTO.Up;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Services.Contracts.Models
{
    public interface IRapportCamera
    {
        /// <summary>
        /// Get all the reports of a camera.
        /// </summary>
        /// <param name="idCamera">Id d'une camera.</param>
        /// <returns>Return liste des rapports pour une camera.</returns>
        public Task<List<RapportCameraDtoUp>> GetRapportCameraByIdCamera(int idCamera);

        /// <summary>
        /// Insert a report for a camera.
        /// </summary>
        /// <param name="rapportCameraDtoUp">Rapport d'une camera.</param>
        /// <returns>code 200.</returns>
        public Task InsertRapportCamera(RapportCameraRegisterDtoDown rapportCameraDtoUp);
    }
}
