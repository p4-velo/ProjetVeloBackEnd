namespace ProjetVeloBackEnd.Entities;

public class Location
{
    public required int Id { get; set; }

    public required string Longitude { get; set; }

    public required string Latitude { get; set; }

    public required string Altitude { get; set; }

    public List<Incident> Incidents { get; set; }
}

