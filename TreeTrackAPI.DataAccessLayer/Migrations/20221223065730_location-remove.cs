using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeTrackAPI.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class locationremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_GardenId",
                table: "Location",
                newName: "IX_Location_GardenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Gardens_GardenId",
                table: "Location",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Gardens_GardenId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Location_GardenId",
                table: "Locations",
                newName: "IX_Locations_GardenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
