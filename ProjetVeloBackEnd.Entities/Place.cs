namespace ProjetVeloBackEnd.Entities;

public class Place
{
    public required int Id { get; set; }

    public required string City { get; set; }

    public required string PostalCode { get; set; }

    public required string Adress { get; set; }

    public required string Name { get; set; }
}