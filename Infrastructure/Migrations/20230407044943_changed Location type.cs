using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedLocationtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Activity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_LocationId",
                table: "Trips",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_LocationId",
                table: "Activity",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Location_LocationId",
                table: "Trips",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Location_LocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_LocationId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Activity_LocationId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Activity");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
