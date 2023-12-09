using Core.Models.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class AuthorSeed
{
    public static void SeedAuthors(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            CreateAuthor(1, "Howard Haugom"),
            CreateAuthor(2, "Laurence Gardner"),
            CreateAuthor(3, "A. K. Howard"));
    }

    private static Author CreateAuthor(int id, string name)
    {
        return new Author
        {
            Id = id,
            Name = name
        };
    }
}