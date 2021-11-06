using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRaceBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runs = table.Column<int>(type: "int", nullable: true),
                    Wins = table.Column<int>(type: "int", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bettors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bet = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    HorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bettors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bettors_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bettors_HorseId",
                table: "Bettors",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bettors");

            migrationBuilder.DropTable(
                name: "Horses");
        }
    }
}
