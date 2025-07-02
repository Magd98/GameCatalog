namespace GameStore.Dtos;

public record class GameSummaryDto
(
    int id,
    string name,
    string genre,
    float price,
    DateOnly releaseDate

);
