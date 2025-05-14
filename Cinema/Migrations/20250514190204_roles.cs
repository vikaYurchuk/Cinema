using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteItems",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItems", x => new { x.UserId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FavoriteItems_FilmTeams4_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTeams4",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteItems_FilmTeams4_UserId1",
                        column: x => x.UserId1,
                        principalTable: "FilmTeams4",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_FilmId",
                table: "FavoriteItems",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItems_UserId1",
                table: "FavoriteItems",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteItems");
        }
    }
}
