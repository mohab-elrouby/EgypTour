using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
