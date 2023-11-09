using Core.Models.Account;
using Core.Models.Catalog;
using Core.Models.Fine;
using Core.Models.LoanManagement;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Configure;

public static class ConfigureModelBuilderExtensions
{
    public static void ConfigureApplicationUserTable(this ModelBuilder modelBuilder)
    {
        // User to Loans (One-to-Many)
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Loans)
            .WithOne(l => l.ApplicationUser)
            .HasForeignKey(l => l.ApplicationUserId);

        // User to Reservations (One-to-Many)
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Reservations)
            .WithOne(r => r.ApplicationUser)
            .HasForeignKey(r => r.ApplicationUserId);

        // User to Fines (One-to-Many)
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Fines)
            .WithOne(f => f.ApplicationUser)
            .HasForeignKey(f => f.ApplicationUserId);
    }
    
    public static void ConfigureBookTable(this ModelBuilder modelBuilder)
    {
        // Books to Loans (One-to-Many)
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Loans)
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId);

        // Books to Reservations (One-to-Many)
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Reservations)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);
    }

    public static void ConfigureAuthorTable(this ModelBuilder modelBuilder)
    {
        // Authors to Books (One-to-Many)
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);
    }

    public static void ConfigurePublisherTable(this ModelBuilder modelBuilder)
    {
        // Publishers to Books (One-to-Many)
        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId);
    }

    public static void ConfigureGenreTable(this ModelBuilder modelBuilder)
    {
        // Genres to Books (One-to-Many)
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId);
    }

    public static void ConfigureLoanTable(this ModelBuilder modelBuilder)
    {
        // Loans to Fines (One-to-One or One-to-None)
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Fines)
            .WithOne(f => f.Loan)
            .HasForeignKey<Fines>(f => f.LoanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}