﻿namespace ProjetVeloBackEnd.Entities;

public class Place : Location
{
    public required string City { get; set; }

    public required string PostalCode { get; set; }

    public required string Adress { get; set; }

    public string Name { get; set; }
}