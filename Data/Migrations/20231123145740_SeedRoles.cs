using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7", null, "Researcher", "RESEARCHER" },
                    { "335c109a-fc01-4738-9b93-4f691e013326", null, "Librarian", "LIBRARIAN" },
                    { "4d9b719f-9fe9-4204-8fcf-53e27a214f84", null, "TechnicalStaff", "TECHNICALSTAFF" },
                    { "837a0b05-8bb3-464f-a992-1cdebe7c40d7", null, "Administrator", "ADMINISTRATOR" },
                    { "9c37fced-a97a-4d3d-9f37-206d711b4bcb", null, "EventManagement", "EVENTMANAGEMENT" },
                    { "a1a8bfa0-3df2-4479-ad7a-c4619a924034", null, "AssistantLibrarian", "ASSISTANTLIBRARIAN" },
                    { "ea9ae32b-bd8f-467c-941d-c4371771adcb", null, "Teacher", "TEACHER" },
                    { "eef91604-9e4c-4d32-a36c-693cb4bed332", null, "Patron", "PATRON" },
                    { "fc7309e9-3d53-42db-b518-95c4e71a2f5e", null, "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "335c109a-fc01-4738-9b93-4f691e013326");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9b719f-9fe9-4204-8fcf-53e27a214f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a0b05-8bb3-464f-a992-1cdebe7c40d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c37fced-a97a-4d3d-9f37-206d711b4bcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a8bfa0-3df2-4479-ad7a-c4619a924034");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea9ae32b-bd8f-467c-941d-c4371771adcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eef91604-9e4c-4d32-a36c-693cb4bed332");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7309e9-3d53-42db-b518-95c4e71a2f5e");
        }
    }
}
