using System;
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GameEndPoints
{
    const string GetGameEndpointName = "GetName";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();

        //GET /games
        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre)
        .Select(game => game.ToGameSummaryDto())
        .AsNoTracking()
        .ToListAsync());

        //Get /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        //POST New Game or Resource
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();


            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();


            GameDetailsDto gameDto = game.ToGameDetailsDto();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.id, }, gameDto);


        });

        //Update Resource

        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            else
            {
                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }
        });


        //DELETE games/1

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.id == id)
            .ExecuteDeleteAsync();
            return Results.NoContent();
        });


        return group;
    }

}
