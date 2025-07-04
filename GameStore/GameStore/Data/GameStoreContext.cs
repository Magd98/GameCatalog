using System;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(

                new Genre { Id = 1, Name = "Fighting" },
                new Genre { Id = 2, Name = "RolePlaying" },
                new Genre { Id = 3, Name = "Sports" },
                new Genre { Id = 4, Name = "Racing" },
                new Genre { Id = 5, Name = "Kids and Family" }

        );

    }
}
