using System;
using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GameEndPoints
{
    const string GetGameEndpointName = "GetName";

    private static readonly List<GameDto> games =
    [
        new(1,
    "Street Fighter II",
    "Fighting",
    60.0f,
    new DateOnly(1992,7,15)),

    new(2,
        "Final Fantasy XVII",
        "RPG",
        79.99f,
        new DateOnly(2010,9,30)),

    new(3,
        "FIFA 2025",
        "Sports",
        90.0f,
        new DateOnly(2024,9,25)),

];


    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();

        //GET /games
        group.MapGet("/", () => games);

        //Get /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        //POST New Game or Resource
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.name,
                newGame.genre,
                newGame.price,
                newGame.releaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.id, }, game);


        });

        //Update Resource

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            else
            {
                games[index] = new GameDto(
                   id,
                   updatedGame.name,
                   updatedGame.genre,
                   updatedGame.price,
                   updatedGame.releaseDate

               );
                return Results.NoContent();
            }
        });


        //DELETE games/1

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.id == id);
            return Results.NoContent();
        });


        return group;
    }

}
