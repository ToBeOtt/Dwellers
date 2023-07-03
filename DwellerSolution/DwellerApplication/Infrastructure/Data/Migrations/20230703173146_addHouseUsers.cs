using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwellerApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addHouseUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseUser_AspNetUsers_AppUserId",
                table: "HouseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseUser_Houses_HouseId",
                table: "HouseUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseUser",
                table: "HouseUser");

            migrationBuilder.RenameTable(
                name: "HouseUser",
                newName: "HouseUsers");

            migrationBuilder.RenameIndex(
                name: "IX_HouseUser_HouseId",
                table: "HouseUsers",
                newName: "IX_HouseUsers_HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseUser_AppUserId",
                table: "HouseUsers",
                newName: "IX_HouseUsers_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseUsers",
                table: "HouseUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseUsers_AspNetUsers_AppUserId",
                table: "HouseUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseUsers_Houses_HouseId",
                table: "HouseUsers",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseUsers_AspNetUsers_AppUserId",
                table: "HouseUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseUsers_Houses_HouseId",
                table: "HouseUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseUsers",
                table: "HouseUsers");

            migrationBuilder.RenameTable(
                name: "HouseUsers",
                newName: "HouseUser");

            migrationBuilder.RenameIndex(
                name: "IX_HouseUsers_HouseId",
                table: "HouseUser",
                newName: "IX_HouseUser_HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseUsers_AppUserId",
                table: "HouseUser",
                newName: "IX_HouseUser_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseUser",
                table: "HouseUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseUser_AspNetUsers_AppUserId",
                table: "HouseUser",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseUser_Houses_HouseId",
                table: "HouseUser",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
