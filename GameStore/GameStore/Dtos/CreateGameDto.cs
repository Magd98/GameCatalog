namespace GameStore.Dtos;

public record class CreateGameDto
(
    string name,
    string genre,
    float price,
    DateOnly releaseDate

);
