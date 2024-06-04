using System.Text.Json.Serialization;

namespace ProjetVeloBackEnd.Entities;

public class FavoritePlace
{
    public required int Id { get; set; }

    public required Location Location { get; set; }

    public required int IdUser { get; set; }

    public required string Name { get; set; }
}