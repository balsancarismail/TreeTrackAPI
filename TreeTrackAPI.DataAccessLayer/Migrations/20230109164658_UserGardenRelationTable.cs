using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeTrackAPI.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserGardenRelationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Gardens_GardenId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Plants_PlantId",
                table: "Note");

            migrationBuilder.DropTable(
                name: "GardenUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Plants",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Note_PlantId",
                table: "Notes",
                newName: "IX_Notes_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_GardenId",
                table: "Notes",
                newName: "IX_Notes_GardenId");

            migrationBuilder.AddColumn<string>(
                name: "Subtype",
                table: "PlantTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Gardens",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserGardens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGardens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGardens_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGardens_GardenId",
                table: "UserGardens",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGardens_UserId",
                table: "UserGardens",
                column: "UserId");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Gardens_GardenId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Plants_PlantId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "UserGardens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Subtype",
                table: "PlantTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Plants",
                newName: "Point");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_PlantId",
                table: "Note",
                newName: "IX_Note_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_GardenId",
                table: "Note",
                newName: "IX_Note_GardenId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Gardens",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Note",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Note",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GardenUser",
                columns: table => new
                {
                    GardensId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenUser", x => new { x.GardensId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GardenUser_Gardens_GardensId",
                        column: x => x.GardensId,
                        principalTable: "Gardens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenUser_UsersId",
                table: "GardenUser",
                column: "UsersId");

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
    }
}
