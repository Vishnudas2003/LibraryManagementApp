using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Account;

public static class RoleSeed
{
    private static IdentityRole<string> CreateRole(string id, string name)
    {
        return new IdentityRole<string>
        {
            Id = id,
            Name = name,
            NormalizedName = name.ToUpper()
        };
    }

    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            CreateRole("837a0b05-8bb3-464f-a992-1cdebe7c40d7", "Administrator"),
            CreateRole("335c109a-fc01-4738-9b93-4f691e013326", "Librarian"),
            CreateRole("a1a8bfa0-3df2-4479-ad7a-c4619a924034", "AssistantLibrarian"),
            CreateRole("4d9b719f-9fe9-4204-8fcf-53e27a214f84", "TechnicalStaff"),
            CreateRole("eef91604-9e4c-4d32-a36c-693cb4bed332", "Patron"),
            CreateRole("01af80e2-1ace-4a3e-bb5f-d16889dd9bc7", "Researcher"),
            CreateRole("9c37fced-a97a-4d3d-9f37-206d711b4bcb", "EventManagement"),
            CreateRole("ea9ae32b-bd8f-467c-941d-c4371771adcb", "Teacher"),
            CreateRole("fc7309e9-3d53-42db-b518-95c4e71a2f5e", "Student"));
    }
}