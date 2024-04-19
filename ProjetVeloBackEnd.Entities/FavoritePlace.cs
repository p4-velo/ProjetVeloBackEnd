namespace ProjetVeloBackEnd.Entities;

public class FavoritePlace
{
    public required int Id { get; set; }

    public required Place Place { get; set; }

    public required User Users { get; set; }

    public required string Name { get; set; }
}