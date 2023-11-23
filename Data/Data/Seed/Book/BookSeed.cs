using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class BookSeed
{
    public static void SeedBooks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Core.Models.Catalog.Book>().HasData(
            CreateBook("08070c0d-fed4-4232-b9d8-311b1a0d3fb7", "Genesis Awakens: An Action Adventure Fantasy with Historical Elements", "1990678092", Convert.ToDateTime("2022-06-23 00:00:00.0000000"), 5, 1),
            CreateBook("334962dd-8f2a-478a-8c87-44414a2ce7ae", "Genesis: The Grail Knight", "9780553825091", Convert.ToDateTime("2023-10-24 00:00:00.0000000"), 5, 2),
            CreateBook("9c4d46ed-9009-4909-925c-05fa58ee89fd", "Forging the Sword: An Action Adventure Fantasy with Historical Elements", "1990678114", Convert.ToDateTime("2022-06-19 00:00:00.0000000"), 5, 3),
            CreateBook("d0af7781-d456-467d-9a5f-176ca3d94c75", "Merlin's Revelation: A Fast-Paced Christian Fantasy", "1990678130", Convert.ToDateTime("2022-09-29 00:00:00.0000000"), 5, 5));
    }

    private static Core.Models.Catalog.Book CreateBook(string id, string title, string isbn, DateTime publicationDateT, int quantity, int genreId)
    {
        return new Core.Models.Catalog.Book
        {
            Id = id,
            StatusId = 1,
            CreatedDateT = DateTime.UtcNow,
            Title = title,
            Isbn = isbn,
            PublicationDateT = publicationDateT,
            Quantity = quantity,
            AuthorId = 1,
            PublisherId = 1,
            GenreId = genreId,
            IsDeleted = false
        };
    }
}