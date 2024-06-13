namespace ProjetVeloBackEnd.Entities;

public class Location
{
    public int? Id { get; set; }

    public required string Longitude { get; set; }

    public required string Latitude { get; set; }

    public required string Altitude { get; set; }
}

