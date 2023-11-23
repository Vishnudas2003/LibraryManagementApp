using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a1a8bfa0-3df2-4479-ad7a-c4619a924034", "13b2a13d-6001-477e-9859-f352097da7e7" },
                    { "335c109a-fc01-4738-9b93-4f691e013326", "4d9c6f2f-0d3b-40f7-9e71-664c3276a413" },
                    { "9c37fced-a97a-4d3d-9f37-206d711b4bcb", "697660f1-6b37-47d6-a0ea-bedce25e0688" },
                    { "ea9ae32b-bd8f-467c-941d-c4371771adcb", "7e06c23c-10a0-435d-8e44-49e5f497cff2" },
                    { "4d9b719f-9fe9-4204-8fcf-53e27a214f84", "7e362909-2567-4e1f-a9ae-e57335eeb14d" },
                    { "837a0b05-8bb3-464f-a992-1cdebe7c40d7", "93c3a7ce-45c4-4be9-8cf5-9030c8748330" },
                    { "eef91604-9e4c-4d32-a36c-693cb4bed332", "a93e2d70-15c0-4ec3-9534-0e4b82d25579" },
                    { "fc7309e9-3d53-42db-b518-95c4e71a2f5e", "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84" },
                    { "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7", "f9526d05-d4ba-41d1-ae8f-e2375fdd7042" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1a8bfa0-3df2-4479-ad7a-c4619a924034", "13b2a13d-6001-477e-9859-f352097da7e7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "335c109a-fc01-4738-9b93-4f691e013326", "4d9c6f2f-0d3b-40f7-9e71-664c3276a413" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c37fced-a97a-4d3d-9f37-206d711b4bcb", "697660f1-6b37-47d6-a0ea-bedce25e0688" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea9ae32b-bd8f-467c-941d-c4371771adcb", "7e06c23c-10a0-435d-8e44-49e5f497cff2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d9b719f-9fe9-4204-8fcf-53e27a214f84", "7e362909-2567-4e1f-a9ae-e57335eeb14d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "837a0b05-8bb3-464f-a992-1cdebe7c40d7", "93c3a7ce-45c4-4be9-8cf5-9030c8748330" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eef91604-9e4c-4d32-a36c-693cb4bed332", "a93e2d70-15c0-4ec3-9534-0e4b82d25579" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc7309e9-3d53-42db-b518-95c4e71a2f5e", "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01af80e2-1ace-4a3e-bb5f-d16889dd9bc7", "f9526d05-d4ba-41d1-ae8f-e2375fdd7042" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b2a13d-6001-477e-9859-f352097da7e7",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d9c6f2f-0d3b-40f7-9e71-664c3276a413",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "697660f1-6b37-47d6-a0ea-bedce25e0688",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e06c23c-10a0-435d-8e44-49e5f497cff2",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e362909-2567-4e1f-a9ae-e57335eeb14d",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93c3a7ce-45c4-4be9-8cf5-9030c8748330",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a93e2d70-15c0-4ec3-9534-0e4b82d25579",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9526d05-d4ba-41d1-ae8f-e2375fdd7042",
                column: "CreatedDateT",
                value: new DateTime(2023, 11, 23, 14, 58, 11, 828, DateTimeKind.Local).AddTicks(913));
        }
    }
}
