namespace ProjetVeloBackEnd.Entities;

public class Favorite
{
    public required int Id { get; set; }

    public required Location Location { get; set; }

    public required User Users { get; set; }

    public required string Name { get; set; }
}