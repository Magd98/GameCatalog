namespace GameStore.Dtos;

public record class GameDetailsDto
(
    int id,
    string name,
    int GenreId,
    float price,
    DateOnly releaseDate

);
