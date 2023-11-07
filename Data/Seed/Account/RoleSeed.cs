using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed.Account;

public static class RoleSeed
{
    private static IdentityRole<string> Administrator()
    {
        return new IdentityRole<string>
        {
            Id = "837a0b05-8bb3-464f-a992-1cdebe7c40d7",
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        };
    }

    private static IdentityRole<string> Librarian()
    {
        return new IdentityRole<string>
        {
            Id = "335c109a-fc01-4738-9b93-4f691e013326",
            Name = "Librarian",
            NormalizedName = "LIBRARIAN"
        };
    }

    private static IdentityRole<string> AssistantLibrarian()
    {
        return new IdentityRole<string>
        {
            Id = "a1a8bfa0-3df2-4479-ad7a-c4619a924034",
            Name = "AssistantLibrarian",
            NormalizedName = "ASSISTANTLIBRARIAN"
        };
    }

    private static IdentityRole<string> TechnicalStaff()
    {
        return new IdentityRole<string>
        {
            Id = "4d9b719f-9fe9-4204-8fcf-53e27a214f84",
            Name = "TechnicalStaff",
            NormalizedName = "TECHNICALSTAFF"
        };
    }

    private static IdentityRole<string> Patron()
    {
        return new IdentityRole<string>
        {
            Id = "eef91604-9e4c-4d32-a36c-693cb4bed332",
            Name = "Patron",
            NormalizedName = "PATRON"
        };
    }

    private static IdentityRole<string> Researcher()
    {
        return new IdentityRole<string>
        {
            Id = "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7",
            Name = "Researcher",
            NormalizedName = "RESEARCHER"
        };
    }

    private static IdentityRole<string> EventManagement()
    {
        return new IdentityRole<string>
        {
            Id = "9c37fced-a97a-4d3d-9f37-206d711b4bcb",
            Name = "EventManagement",
            NormalizedName = "EVENTMANAGEMENT"
        };
    }

    private static IdentityRole<string> Teacher()
    {
        return new IdentityRole<string>
        {
            Id = "ea9ae32b-bd8f-467c-941d-c4371771adcb",
            Name = "Teacher",
            NormalizedName = "TEACHER"
        };
    }
    
    private static IdentityRole<string> Student()
    {
        return new IdentityRole<string>
        {
            Id = "fc7309e9-3d53-42db-b518-95c4e71a2f5e",
            Name = "Student",
            NormalizedName = "STUDENT"
        };
    }
    
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            Administrator(),
            Librarian(),
            AssistantLibrarian(),
            TechnicalStaff(),
            Patron(),
            Researcher(),
            EventManagement(),
            Teacher(),
            Student()
        );
    }
}