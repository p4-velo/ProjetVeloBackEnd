namespace ProjetVeloBackEnd.Entities;

public class Incident : Location
{
    public required IncidentType IncidentType { get; set; }

    public required int CountFinished { get; set; } = 0;
}

