using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetVeloBackEnd.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlaceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePlace");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "User",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Location",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<int>(
                name: "CountFinished",
                table: "Location",
                type: "int",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentTypeId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Location",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "IncidentType",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Location_IncidentTypeId",
                table: "Location",
                column: "IncidentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_IncidentType_IncidentTypeId",
                table: "Location",
                column: "IncidentTypeId",
                principalTable: "IncidentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_IncidentType_IncidentTypeId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_IncidentTypeId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CountFinished",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IncidentTypeId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "IncidentType");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Location",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.CreateTable(
                name: "FavoritePlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePlace_Location_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritePlace_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CountFinished = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incident_IncidentType_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlace_PlaceId",
                table: "FavoritePlace",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlace_UserId",
                table: "FavoritePlace",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IncidentTypeId",
                table: "Incident",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_LocationId",
                table: "Incident",
                column: "LocationId");
        }
    }
}
