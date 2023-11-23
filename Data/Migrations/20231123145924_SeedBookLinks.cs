using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "AK", "Howard" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "GenreType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Mystery" },
                    { 2, 1, "Thriller" },
                    { 3, 1, "Horror" },
                    { 4, 1, "Historical Fiction" },
                    { 5, 1, "Romance" },
                    { 6, 1, "Science Fiction" },
                    { 7, 1, "Fantasy" },
                    { 8, 1, "Dystopian" },
                    { 9, 1, "Adventure" },
                    { 10, 1, "Young Adult (YA)" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Footnail Press" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b2a13d-6001-477e-9859-f352097da7e7",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "697660f1-6b37-47d6-a0ea-bedce25e0688",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e06c23c-10a0-435d-8e44-49e5f497cff2",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e362909-2567-4e1f-a9ae-e57335eeb14d",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8527));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 46, 166, DateTimeKind.Local).AddTicks(8539));
        }
    }
}
