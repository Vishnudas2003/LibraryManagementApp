using Core.Enums;
using Core.Models.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class GenreSeed
{
    public static void SeedGenres(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            CreateGenre(1,  GenreType.Fictional , "Mystery"),
            CreateGenre(2,  GenreType.Fictional , "Thriller"),
            CreateGenre(3,  GenreType.Fictional , "Horror"),
            CreateGenre(4,  GenreType.Fictional , "Historical Fiction"),
            CreateGenre(5,  GenreType.Fictional , "Romance"),
            CreateGenre(6,  GenreType.Fictional , "Science Fiction"),
            CreateGenre(7,  GenreType.Fictional , "Fantasy"),
            CreateGenre(8,  GenreType.Fictional , "Dystopian"),
            CreateGenre(9,  GenreType.Fictional , "Adventure"),
            CreateGenre(10, GenreType.Fictional , "Young Adult (YA)")
        );
    }

    private static Genre CreateGenre(int id, GenreType genreType, string name)
    {
        return new Genre
        {
            Id = id,
            GenreType = genreType,
            Name = name
        };
    }
}