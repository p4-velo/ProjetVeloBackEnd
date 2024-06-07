using Microsoft.AspNetCore.Identity;

namespace ProjetVeloBackEnd.Entities;

public class User : IdentityUser
{

    public int Xp { get; set; } = 0;

    public User()
    {
    }
}