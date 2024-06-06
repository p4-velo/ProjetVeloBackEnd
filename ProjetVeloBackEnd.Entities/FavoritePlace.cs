namespace ProjetVeloBackEnd.Entities;

public class FavoritePlace : Place
{
    public required int idUser { get; set; }

    public required string Title { get; set; }
}