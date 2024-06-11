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
        public int GaucheADroite { get; set; }
        public int DroiteAGauche { get; set; }
        public required DateTime Date { get; set; }
    }
}
