using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckoutDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDateT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDateT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FineDateT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateT", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDateT", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StatusId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13b2a13d-6001-477e-9859-f352097da7e7", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2689), "assistantlibrarian@test.com", true, false, null, null, "ASSISTANTLIBRARIAN@TEST.COM", "ASSISTANTLIBRARIAN", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "AssistantLibrarian" },
                    { "4d9c6f2f-0d3b-40f7-9e71-664c3276a413", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2648), "librarian@test.com", true, false, null, null, "LIBRARIAN@TEST.COM", "LIBRARIAN", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Librarian" },
                    { "697660f1-6b37-47d6-a0ea-bedce25e0688", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2883), "eventmanagement@test.com", true, false, null, null, "EVENTMANAGEMENT@TEST.COM", "EVENTMANAGEMENT", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "EventManagement" },
                    { "7e06c23c-10a0-435d-8e44-49e5f497cff2", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2893), "teacher@test.com", true, false, null, null, "TEACHER@TEST.COM", "TEACHER", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Teacher" },
                    { "7e362909-2567-4e1f-a9ae-e57335eeb14d", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2696), "technicalstaff@test.com", true, false, null, null, "TECHNICALSTAFF@TEST.COM", "TECHNICALSTAFF", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "TechnicalStaff" },
                    { "93c3a7ce-45c4-4be9-8cf5-9030c8748330", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2458), "administrator@test.com", true, false, null, null, "ADMINISTRATOR@TEST.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Administrator" },
                    { "a93e2d70-15c0-4ec3-9534-0e4b82d25579", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2705), "patron@test.com", true, false, null, null, "PATRON@TEST.COM", "PATRON", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Patron" },
                    { "f32ec246-ba2c-4fd4-8fb3-3f7b42389f84", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2900), "student@test.com", true, false, null, null, "STUDENT@TEST.COM", "STUDENT", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Student" },
                    { "f9526d05-d4ba-41d1-ae8f-e2375fdd7042", 0, "07e1940e-7b71-4607-beaa-e4cd284d491b", new DateTime(2023, 11, 22, 16, 10, 17, 476, DateTimeKind.Local).AddTicks(2720), "researcher@test.com", true, false, null, null, "RESEARCHER@TEST.COM", "RESEARCHER", "AQAAAAIAAYagAAAAEMYIf70Mja5pAtAr42rkE/hUsS0WQQWrcls3ej3IZ5/lu8ARMvhBifvz7DAbPonCAw==", null, false, "E7XEF5G2WXH7N5B52N7QPC5QOOK64YO7", 1, false, "Researcher" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_ApplicationUserId",
                table: "Fines",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_LoanId",
                table: "Fines",
                column: "LoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ApplicationUserId",
                table: "Loan",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_BookId",
                table: "Loan",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ApplicationUserId",
                table: "Reservation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
