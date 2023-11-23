using Core.Models.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Book;

public static class PublisherSeed
{
    public static void SeedPublishers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>().HasData(
            CreatePublisher(1, "Footnail Press"));
    }

    private static Publisher CreatePublisher(int id, string name)
    {
        return new Publisher
        {
            Id = id,
            Name = name
        };
    }
}