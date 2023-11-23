using Core.Enums;
using Core.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Seed.Account;

public static class AccountSeed
{
    private static ApplicationUser CreateUser(string id, string role, string email)
    {
        return new ApplicationUser
        {
            Id = id,
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = role,
            NormalizedUserName = role.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==",
            SecurityStamp = "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7",
            ConcurrencyStamp = "07e1940e-7b71-4607-beaa-e4cd284d491b",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
    }

    public static void SeedAccounts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>().HasData(
            CreateUser("93c3a7ce-45c4-4be9-8cf5-9030c8748330", "Administrator", "administrator@test.com"),
            CreateUser("4d9c6f2f-0d3b-40f7-9e71-664c3276a413", "Librarian", "librarian@test.com"),
            CreateUser("13b2a13d-6001-477e-9859-f352097da7e7", "AssistantLibrarian", "assistantlibrarian@test.com"),
            CreateUser("7e362909-2567-4e1f-a9ae-e57335eeb14d", "TechnicalStaff", "technicalstaff@test.com"),
            CreateUser("a93e2d70-15c0-4ec3-9534-0e4b82d25579", "Patron", "patron@test.com"),
            CreateUser("f9526d05-d4ba-41d1-ae8f-e2375fdd7042", "Researcher", "researcher@test.com"),
            CreateUser("697660f1-6b37-47d6-a0ea-bedce25e0688", "EventManagement", "eventmanagement@test.com"),
            CreateUser("7e06c23c-10a0-435d-8e44-49e5f497cff2", "Teacher", "teacher@test.com"),
            CreateUser("f32ec246-ba2c-4fd4-8fb3-3f7b42389f84", "Student", "student@test.com"));
    }
}