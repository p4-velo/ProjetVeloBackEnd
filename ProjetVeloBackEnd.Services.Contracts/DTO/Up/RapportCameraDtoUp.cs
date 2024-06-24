using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Services.Contracts.DTO.Up
{
    public class RapportCameraDtoUp
    {
        public required int Id { get; set; }
        public required int IdCamera { get; set; }
        public required int NombrePlace { get; set; }
        public required int NombreVelos { get; set; }
        public required DateTime Date { get; set; }
    }
}
