﻿namespace ProjetVeloBackEnd.Entities;

public class FavoritePlace : Place
{
    public required int IdUser { get; set; }

    public required string Title { get; set; }
}