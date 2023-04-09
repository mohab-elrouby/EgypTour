using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_TouristId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TouristId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TouristId",
                table: "User",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_TouristId",
                table: "User",
                column: "TouristId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
