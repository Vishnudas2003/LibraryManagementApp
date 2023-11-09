using Data.Data.Configure;
using Data.Data.Seed.Account;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureApplicationUserTable();
        modelBuilder.ConfigureBookTable();
        modelBuilder.ConfigureAuthorTable();
        modelBuilder.ConfigurePublisherTable();
        modelBuilder.ConfigureGenreTable();
        modelBuilder.ConfigureLoanTable();
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedRoles();
        modelBuilder.SeedAccounts();
        modelBuilder.SeedUserRoles();
    }
}