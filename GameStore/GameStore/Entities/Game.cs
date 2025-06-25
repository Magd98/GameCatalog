using System;

namespace GameStore.Entities;

public class Game
{
    public int id { get; set; }

    public required string name { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }
    public float price { get; set; }

    public DateOnly releaseDate { get; set; }

}
