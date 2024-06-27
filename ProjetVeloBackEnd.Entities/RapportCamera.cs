using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Entities
{
    public class RapportCamera
    {
        public int Id { get; set; }
        public required int IdCamera { get; set; }
        public required int NombrePlace { get; set; }
        public required int NombreVelos { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
