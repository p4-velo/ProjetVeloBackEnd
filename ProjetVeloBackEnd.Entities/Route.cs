using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVeloBackEnd.Entities;

public class Route
{
    public required int Id { get; set; }
    public required User User { get; set; }
    public required Place StartPlace { get; set; }
    public required Place EndPlace { get; set; }
    public List<Location> WayPoints { get; set; }
}