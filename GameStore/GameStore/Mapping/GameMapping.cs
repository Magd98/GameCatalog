using System;
using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            name = game.name,
            GenreId = game.GenreId,
            price = game.price,
            releaseDate = game.releaseDate,
        };
    }


    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new
            (
                game.id,
                game.name,
                game.Genre!.Name,
                game.price,
                game.releaseDate
            );
    }





    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new
            (
                game.id,
                game.name,
                game.GenreId,
                game.price,
                game.releaseDate
            );
    }



    public static Game ToEntity(this UpdateGameDto game, int id)
    {
        return new Game()
        {
            id = id,
            name = game.name,
            GenreId = game.GenreId,
            price = game.price,
            releaseDate = game.releaseDate,
        };
    }
}
