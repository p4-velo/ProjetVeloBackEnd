﻿namespace ProjetVeloBackEnd.Entities;

public class Favorite
{
    public required int Id { get; set; }

    public required Place Place { get; set; }

    public required User User { get; set; }

    public required string Name { get; set; }
}