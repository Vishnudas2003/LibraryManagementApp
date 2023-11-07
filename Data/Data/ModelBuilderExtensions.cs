using Data.Seed.Account;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedRoles();
    }
}