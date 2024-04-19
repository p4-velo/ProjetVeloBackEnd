namespace ProjetVeloBackEnd.Entities;

public class User
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Pseudo { get; set; }

    public required string Password { get; set; }

    public bool IsAdmin { get; set; }

    public List<Favorite> Favorites { get; set; }

}