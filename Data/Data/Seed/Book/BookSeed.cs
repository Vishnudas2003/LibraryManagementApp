using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class BookSeed
{
    public static void SeedBooks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Core.Models.Catalog.Book>().HasData(
            CreateBook(
                "08070c0d-fed4-4232-b9d8-311b1a0d3fb7",
                "Genesis Awakens: An Action Adventure Fantasy with Historical Elements",
                "The Astonishing Story of the Ancient Bloodline of Christ and the True Heritage of the Holy Grail",
                "1990678092",
                "Book",
                Convert.ToDateTime("2022-06-23 00:00:00.0000000"),
                4,
                2,
                2,
                837,
                423
            ),
            CreateBook(
                "334962dd-8f2a-478a-8c87-44414a2ce7ae", 
                "Genesis of the Grail Kings", 
                "N/A",
                "9780553825091",
                "Book",
                Convert.ToDateTime("2009-12-08 00:00:00.0000000"), 
                5,
                1, 
                1,
                837,
                278
                ),
            CreateBook(
                "9c4d46ed-9009-4909-925c-05fa58ee89fd",
                "Forging the Sword: An Action Adventure Fantasy with Historical Elements", 
                "N/A",
                "1990678114",
                "Book",
                Convert.ToDateTime("2022-07-20 00:00:00.0000000"), 
                3, 
                1,
                1,
                837,
                240
                ),
            CreateBook(
                "d0af7781-d456-467d-9a5f-176ca3d94c75", 
                "Merlin's Revelation: A Fast-Paced Christian Fantasy", 
                "N/A",
                "1990678130", 
                "Book",
                Convert.ToDateTime("2022-09-29 00:00:00.0000000"), 
                5, 
                3,
                1,
                837,
                242
                ));
    }

    private static Core.Models.Catalog.Book CreateBook(string id, string title, string? subTitle, string isbn,
        string printType, DateTime publicationDateT, int quantity, int authorId, int publisherId, int genreId, int pageCount)
    {
        return new Core.Models.Catalog.Book
        {
            Id = id,
            Title = title,
            Subtitle = subTitle,
            Isbn = isbn,
            PrintType = printType,
            PublicationDateT = publicationDateT,
            Quantity = quantity,
            AuthorId = authorId,
            PublisherId = publisherId,
            GenreId = genreId,
            PageCount = pageCount,
            IsDeleted = false,
            Status = Status.Active,
            CreatedDateT = DateTime.UtcNow
        };
    }
}