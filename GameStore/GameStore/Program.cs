using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



const string GetGameEndpointName = "GetName";

List<GameDto> games =
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

//GET /games
app.MapGet("games", () => games);

//Get /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.id == id)).WithName(GetGameEndpointName);


app.MapPost("games", (CreateGameDto newGame) =>
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



app.Run();

