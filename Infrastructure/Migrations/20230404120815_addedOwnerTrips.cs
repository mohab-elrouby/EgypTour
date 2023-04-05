using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedOwnerTrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_OwnerId",
                table: "Trips",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_User_OwnerId",
                table: "Trips",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_User_OwnerId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_OwnerId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Trips");
        }
    }
}
