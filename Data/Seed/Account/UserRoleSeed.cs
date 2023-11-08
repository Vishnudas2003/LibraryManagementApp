﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed.Account;

public static class UserRoleSeed
{
        private static IdentityUserRole<string> Administrator()
    {
        return new IdentityUserRole<string>
        {
            UserId = "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
            RoleId = "837a0b05-8bb3-464f-a992-1cdebe7c40d7"
        };
    }

    private static IdentityUserRole<string> Librarian()
    {
        return new IdentityUserRole<string>
        {
            UserId = "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
            RoleId = "335c109a-fc01-4738-9b93-4f691e013326"
        };
    }

    private static IdentityUserRole<string> AssistantLibrarian()
    {
        return new IdentityUserRole<string>
        {
            UserId = "13b2a13d-6001-477e-9859-f352097da7e7",
            RoleId = "a1a8bfa0-3df2-4479-ad7a-c4619a924034"
        };
    }

    private static IdentityUserRole<string> TechnicalStaff()
    {
        return new IdentityUserRole<string>
        {
            UserId = "7e362909-2567-4e1f-a9ae-e57335eeb14d",
            RoleId = "4d9b719f-9fe9-4204-8fcf-53e27a214f84"
        };
    }

    private static IdentityUserRole<string> Patron()
    {
        return new IdentityUserRole<string>
        {
            UserId = "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
            RoleId = "eef91604-9e4c-4d32-a36c-693cb4bed332"
        };
    }

    private static IdentityUserRole<string> Researcher()
    {
        return new IdentityUserRole<string>
        {
            UserId = "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
            RoleId = "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7"
        };
    }

    private static IdentityUserRole<string> EventManagement()
    {
        return new IdentityUserRole<string>
        {
            UserId = "697660f1-6b37-47d6-a0ea-bedce25e0688",
            RoleId = "9c37fced-a97a-4d3d-9f37-206d711b4bcb"
        };
    }

    private static IdentityUserRole<string> Teacher()
    {
        return new IdentityUserRole<string>
        {
            UserId = "7e06c23c-10a0-435d-8e44-49e5f497cff2",
            RoleId = "ea9ae32b-bd8f-467c-941d-c4371771adcb"
        };
    }
    
    private static IdentityUserRole<string> Student()
    {
        return new IdentityUserRole<string>
        {
            UserId = "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
            RoleId = "fc7309e9-3d53-42db-b518-95c4e71a2f5e"
        };
    }
    
    public static void SeedUserRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
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