using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace TreeTrackAPI.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class geopointandgeopolyaddittion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Locations_LocationId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_LocationId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Plants");

            migrationBuilder.AddColumn<Point>(
                name: "Point",
                table: "Plants",
                type: "geography",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GardenId",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Polygon>(
                name: "Polygon",
                table: "Gardens",
                type: "geography",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Polygon",
                table: "Gardens");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GardenId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LocationId",
                table: "Plants",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Gardens_GardenId",
                table: "Locations",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Locations_LocationId",
                table: "Plants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
