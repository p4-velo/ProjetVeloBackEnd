using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetVeloBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRapportCamera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GaucheADroite",
                table: "RapportCamera",
                newName: "NombreVelos");

            migrationBuilder.RenameColumn(
                name: "DroiteAGauche",
                table: "RapportCamera",
                newName: "NombrePlace");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreVelos",
                table: "RapportCamera",
                newName: "GaucheADroite");

            migrationBuilder.RenameColumn(
                name: "NombrePlace",
                table: "RapportCamera",
                newName: "DroiteAGauche");
        }
    }
}
