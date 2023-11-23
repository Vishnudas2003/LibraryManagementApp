using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateT", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDateT", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StatusId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13b2a13d-6001-477e-9859-f352097da7e7", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(890), "assistantlibrarian@test.com", true, false, null, null, "ASSISTANTLIBRARIAN@TEST.COM", "ASSISTANTLIBRARIAN", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "AssistantLibrarian" },
                    { "4d9c6f2f-0d3b-40f7-9e71-664c3276a413", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(880), "librarian@test.com", true, false, null, null, "LIBRARIAN@TEST.COM", "LIBRARIAN", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Librarian" },
                    { "697660f1-6b37-47d6-a0ea-bedce25e0688", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(919), "eventmanagement@test.com", true, false, null, null, "EVENTMANAGEMENT@TEST.COM", "EVENTMANAGEMENT", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "EventManagement" },
                    { "7e06c23c-10a0-435d-8e44-49e5f497cff2", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(925), "teacher@test.com", true, false, null, null, "TEACHER@TEST.COM", "TEACHER", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Teacher" },
                    { "7e362909-2567-4e1f-a9ae-e57335eeb14d", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(898), "technicalstaff@test.com", true, false, null, null, "TECHNICALSTAFF@TEST.COM", "TECHNICALSTAFF", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "TechnicalStaff" },
                    { "93c3a7ce-45c4-4be9-8cf5-9030c8748330", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(815), "administrator@test.com", true, false, null, null, "ADMINISTRATOR@TEST.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Administrator" },
                    { "a93e2d70-15c0-4ec3-9534-0e4b82d25579", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(904), "patron@test.com", true, false, null, null, "PATRON@TEST.COM", "PATRON", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Patron" },
                    { "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(933), "student@test.com", true, false, null, null, "STUDENT@TEST.COM", "STUDENT", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Student" },
                    { "f9526d05-d4ba-41d1-ae8f-e2375fdd7042", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(913), "researcher@test.com", true, false, null, null, "RESEARCHER@TEST.COM", "RESEARCHER", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Researcher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b2a13d-6001-477e-9859-f352097da7e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d9c6f2f-0d3b-40f7-9e71-664c3276a413");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "697660f1-6b37-47d6-a0ea-bedce25e0688");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e06c23c-10a0-435d-8e44-49e5f497cff2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e362909-2567-4e1f-a9ae-e57335eeb14d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c3a7ce-45c4-4be9-8cf5-9030c8748330");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a93e2d70-15c0-4ec3-9534-0e4b82d25579");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9526d05-d4ba-41d1-ae8f-e2375fdd7042");
        }
    }
}
