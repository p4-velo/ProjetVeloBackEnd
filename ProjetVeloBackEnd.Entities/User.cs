using Microsoft.AspNetCore.Identity;

namespace ProjetVeloBackEnd.Entities;

public class User : IdentityUser
{
    public int Id { get; set; }


    public List<FavoritePlace>? FavoritePlaces { get; set; }

    public User()
    {
        FavoritePlaces = new List<FavoritePlace>();
    }
}