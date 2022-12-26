using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeTrackAPI.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Gardens_GardenId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Plants_PlantId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_PlantId",
                table: "Note",
                newName: "IX_Note_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_GardenId",
                table: "Note",
                newName: "IX_Note_GardenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Gardens_GardenId",
                table: "Note",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Plants_PlantId",
                table: "Note",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Gardens_GardenId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Plants_PlantId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Note_PlantId",
                table: "Notes",
                newName: "IX_Notes_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_GardenId",
                table: "Notes",
                newName: "IX_Notes_GardenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_GardenId",
                table: "Location",
                column: "GardenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Gardens_GardenId",
                table: "Notes",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Plants_PlantId",
                table: "Notes",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
