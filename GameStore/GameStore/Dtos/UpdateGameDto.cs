using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class UpdateGameDto
(
    [Required][StringLength(50)] string name,
    int GenreId,
    [Range(1, 100)] float price,
    DateOnly releaseDate
);
