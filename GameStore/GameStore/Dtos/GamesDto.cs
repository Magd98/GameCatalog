namespace GameStore.Dtos;

public record class GameDto
(
    int id,
    string name,
    string genre,
    float price,
    DateOnly releaseDate

);
