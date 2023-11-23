using Core.Models.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class AuthorSeed
{
    public static void SeedAuthors(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            CreateAuthor(1, "AK", "Howard"));
    }

    private static Author CreateAuthor(int id, string firstName, string lastName)
    {
        return new Author
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };
    }
}