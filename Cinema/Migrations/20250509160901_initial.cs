using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmTeams4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmTeams4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CinemaActors4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaActors4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaActors4_FilmTeams4_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTeams4",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Hall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_FilmTeams4_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTeams4",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FilmTeams4",
                columns: new[] { "Id", "Cover", "Duration", "Genre", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "https://www.musiconvinyl.com/cdn/shop/files/MOVATM091_Sleeve.webp?v=1713507987&width=1445", 142, "Drama", "The Shawshank Redemption", 1994 },
                    { 2, "https://www.northjersey.com/gcdn/presto/2022/03/22/PNJM/0d896a12-005e-4d8f-b29f-19595efd5c6f-The_Godfather_50th.jpg?width=600&height=904&fit=crop&format=pjpg&auto=webp", 175, "Crime, Drama", "The Godfather", 1972 },
                    { 3, "https://m.media-amazon.com/images/S/pv-target-images/e9a43e647b2ca70e75a3c0af046c4dfdcd712380889779cbdc2c57d94ab63902.jpg", 152, "Action, Crime, Drama", "The Dark Knight", 2008 },
                    { 4, "https://upload.wikimedia.org/wikipedia/ru/d/de/%D0%A4%D0%BE%D1%80%D1%80%D0%B5%D1%81%D1%82_%D0%93%D0%B0%D0%BC%D0%BF.jpg", 142, "Drama, Romance", "Forrest Gump", 1994 },
                    { 5, "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg", 148, "Action, Adventure, Sci-Fi", "Inception", 2010 },
                    { 6, "https://i.scdn.co/image/ab67616d0000b273cb10bbc00c7732aec1b81fb2", 136, "Action, Sci-Fi", "The Matrix", 1999 },
                    { 7, "https://upload.wikimedia.org/wikipedia/en/3/3f/The_Empire_Strikes_Back_%281980_film%29.jpg", 124, "Action, Adventure, Fantasy", "The Empire Strikes Back", 1980 },
                    { 8, "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg", 154, "Crime, Drama", "Pulp Fiction", 1994 },
                    { 9, "https://upload.wikimedia.org/wikipedia/en/1/18/Titanic_%281997_film%29_poster.png", 195, "Drama, Romance", "Titanic", 1997 },
                    { 10, "https://lumiere-a.akamaihd.net/v1/images/avatar_800x1200_208c9665.jpeg?region=0%2C0%2C800%2C1200", 162, "Sci-Fi, Adventure", "Avatar", 2009 },
                    { 11, "https://m.media-amazon.com/images/M/MV5BNzY3OWQ5NDktNWQ2OC00ZjdlLThkMmItMDhhNDk3NTFiZGU4XkEyXkFqcGc@._V1_.jpg", 122, "Drama, Thriller", "Joker", 2019 },
                    { 12, "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", 181, "Action, Sci-Fi", "Avengers: Endgame", 2019 }
                });

            migrationBuilder.InsertData(
                table: "CinemaActors4",
                columns: new[] { "Id", "FilmId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Tim", "Robbins" },
                    { 2, 1, "Morgan", "Freeman" },
                    { 3, 2, "Marlon", "Brando" },
                    { 4, 2, "Al", "Pacino" },
                    { 5, 3, "Christian", "Bale" },
                    { 6, 3, "Heath", "Ledger" },
                    { 7, 4, "Tom", "Hanks" },
                    { 8, 4, "Robin", "Wright" },
                    { 9, 5, "Leonardo", "DiCaprio" },
                    { 10, 5, "Joseph", "Gordon-Levitt" },
                    { 11, 6, "Keanu", "Reeves" },
                    { 12, 6, "Laurence", "Fishburne" },
                    { 13, 7, "Harrison", "Ford" },
                    { 14, 7, "Mark", "Hamill" },
                    { 15, 7, "Markus", "Hamillian" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "FilmId", "Hall", "Price", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, "Main Hall", 150.00m, new DateTime(2025, 5, 10, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 7, "VIP Hall", 200.00m, new DateTime(2025, 5, 11, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 8, "Hall 2", 140.00m, new DateTime(2025, 5, 12, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 9, "Hall 3", 180.00m, new DateTime(2025, 5, 12, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 10, "IMAX", 220.00m, new DateTime(2025, 5, 13, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 11, "Hall 1", 160.00m, new DateTime(2025, 5, 13, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 12, "Main Hall", 210.00m, new DateTime(2025, 5, 14, 16, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, "VIP Hall", 170.00m, new DateTime(2025, 5, 15, 19, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaActors4_FilmId",
                table: "CinemaActors4",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaActors4");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "FilmTeams4");
        }
    }
}
