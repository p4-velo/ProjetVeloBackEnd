using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Entities
{
    public class VeloPark : Location
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public int RemainingCapacity { get; set; }

        public VeloParkType veloParkType { get; set; }
    }
}
