using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetVeloBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createRapportCamera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RapportCamera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCamera = table.Column<int>(type: "int", nullable: false),
                    GaucheADroite = table.Column<int>(type: "int", nullable: false),
                    DroiteAGauche = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapportCamera", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RapportCamera");
        }
    }
}
