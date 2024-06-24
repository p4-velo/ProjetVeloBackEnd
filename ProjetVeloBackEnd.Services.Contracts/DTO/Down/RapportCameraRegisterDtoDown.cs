using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Down
{
    public class RapportCameraRegisterDtoDown
    {
        public required int IdCamera { get; set; }
        public int NombrePlace { get; set; }
        public int NombreVelos { get; set; }
    }
}
