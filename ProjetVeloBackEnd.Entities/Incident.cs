namespace ProjetVeloBackEnd.Entities;

public class Incident
{
    public required int Id { get; set; }

    public required Location Location { get; set; }

    public required IncidentType IncidentType { get; set; }

    public required int CountFinished { get; set; } = 0;
}

