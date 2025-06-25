using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CreateGameDto
(
    [Required][StringLength(50)] string name,
    [Required][StringLength(20)] string genre,
    [Range(1, 100)] float price,
    DateOnly releaseDate

);
