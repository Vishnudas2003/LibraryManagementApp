using Core.Models.Account;
using Core.Models.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // User
    public DbSet<ApplicationUser>? ApplicationUser { get; set; }
    public DbSet<IdentityRole>? Role { get; set; }
    public DbSet<Book>? Book { get; set; }
    public DbSet<Author>? Author { get; set; }
    public DbSet<Publisher>? Publisher { get; set; }
    public DbSet<Genre>? Genre { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}