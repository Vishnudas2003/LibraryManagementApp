using Core.Enums;
using Core.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed.Account;

public static class AccountSeed
{
    private static ApplicationUser Administrator()
    {
        return new ApplicationUser
        {
            Id = "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Administrator",
            NormalizedUserName = "ADMINISTRATOR",
            Email = "administrator@test.com",
            NormalizedEmail = "ADMINISTRATOR@TEST.COM",
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
    
    private static ApplicationUser Librarian()
    {
        return new ApplicationUser
        {
            Id = "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Librarian",
            NormalizedUserName = "LIBRARIAN",
            Email = "librarian@test.com",
            NormalizedEmail = "LIBRARIAN@TEST.COM",
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
    
    private static ApplicationUser AssistantLibrarian()
    {
        return new ApplicationUser
        {
            Id = "13b2a13d-6001-477e-9859-f352097da7e7",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "AssistantLibrarian",
            NormalizedUserName = "ASSISTANTLIBRARIAN",
            Email = "assistantlibrarian@test.com",
            NormalizedEmail = "ASSISTANTLIBRARIAN@TEST.COM",
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
    
    private static ApplicationUser TechnicalStaff()
    {
        return new ApplicationUser
        {
            Id = "7e362909-2567-4e1f-a9ae-e57335eeb14d",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "TechnicalStaff",
            NormalizedUserName = "TECHNICALSTAFF",
            Email = "technicalstaff@test.com",
            NormalizedEmail = "TECHNICALSTAFF@TEST.COM",
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
    
    private static ApplicationUser Patron()
    {
        return new ApplicationUser
        {
            Id = "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Patron",
            NormalizedUserName = "PATRON",
            Email = "patron@test.com",
            NormalizedEmail = "PATRON@TEST.COM",
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
    
    private static ApplicationUser Researcher()
    {
        return new ApplicationUser
        {
            Id = "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Researcher",
            NormalizedUserName = "RESEARCHER",
            Email = "researcher@test.com",
            NormalizedEmail = "RESEARCHER@TEST.COM",
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
    
    private static ApplicationUser EventManagement()
    {
        return new ApplicationUser
        {
            Id = "697660f1-6b37-47d6-a0ea-bedce25e0688",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "EventManagement",
            NormalizedUserName = "EVENTMANAGEMENT",
            Email = "eventmanagement@test.com",
            NormalizedEmail = "EVENTMANAGEMENT@TEST.COM",
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
    
    
    
    private static ApplicationUser Teacher()
    {
        return new ApplicationUser
        {
            Id = "7e06c23c-10a0-435d-8e44-49e5f497cff2",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Teacher",
            NormalizedUserName = "TEACHER",
            Email = "teacher@test.com",
            NormalizedEmail = "TEACHER@TEST.COM",
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
    
    private static ApplicationUser Student()
    {
        return new ApplicationUser
        {
            Id = "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.Now,
            UserName = "Student",
            NormalizedUserName = "STUDENT",
            Email = "student@test.com",
            NormalizedEmail = "STUDENT@TEST.COM",
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