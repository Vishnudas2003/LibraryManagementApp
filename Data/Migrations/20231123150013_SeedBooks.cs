using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b2a13d-6001-477e-9859-f352097da7e7",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "697660f1-6b37-47d6-a0ea-bedce25e0688",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e06c23c-10a0-435d-8e44-49e5f497cff2",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e362909-2567-4e1f-a9ae-e57335eeb14d",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CreatedDateT", "DeletedDateT", "GenreId", "IsDeleted", "Isbn", "ModifiedDateT", "PublicationDateT", "PublisherId", "Quantity", "StatusId", "Title" },
                values: new object[,]
                {
                    { "08070c0d-fed4-4232-b9d8-311b1a0d3fb7", 1, new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Utc).AddTicks(7232), null, 1, false, "1990678092", null, new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Genesis Awakens: An Action Adventure Fantasy with Historical Elements" },
                    { "334962dd-8f2a-478a-8c87-44414a2ce7ae", 1, new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Utc).AddTicks(7245), null, 2, false, "9780553825091", null, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Genesis: The Grail Knight" },
                    { "9c4d46ed-9009-4909-925c-05fa58ee89fd", 1, new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Utc).AddTicks(7251), null, 3, false, "1990678114", null, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Forging the Sword: An Action Adventure Fantasy with Historical Elements" },
                    { "d0af7781-d456-467d-9a5f-176ca3d94c75", 1, new DateTime(2023, 11, 23, 15, 0, 13, 40, DateTimeKind.Utc).AddTicks(7257), null, 5, false, "1990678130", null, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, "Merlin's Revelation: A Fast-Paced Christian Fantasy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: "08070c0d-fed4-4232-b9d8-311b1a0d3fb7");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: "334962dd-8f2a-478a-8c87-44414a2ce7ae");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: "9c4d46ed-9009-4909-925c-05fa58ee89fd");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: "d0af7781-d456-467d-9a5f-176ca3d94c75");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b2a13d-6001-477e-9859-f352097da7e7",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "697660f1-6b37-47d6-a0ea-bedce25e0688",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e06c23c-10a0-435d-8e44-49e5f497cff2",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e362909-2567-4e1f-a9ae-e57335eeb14d",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 59, 24, 38, DateTimeKind.Local).AddTicks(7740));
        }
    }
}
