using System.Text.Json.Serialization;

namespace ProjetVeloBackEnd.Entities;

public class FavoritePlace
{
    public required int Id { get; set; }

    public required Place Place { get; set; }

    public required int idUser { get; set; }

    public required string Name { get; set; }
}