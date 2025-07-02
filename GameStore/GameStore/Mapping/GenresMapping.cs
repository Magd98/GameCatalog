using System;
using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GenresMapping
{
    public static GenresDto ToDto(this Genre genres)
    {
        return new GenresDto(genres.Id, genres.Name);
    }
}
