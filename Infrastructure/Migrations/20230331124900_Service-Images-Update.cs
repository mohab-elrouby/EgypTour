using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ServiceImagesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ServiceId",
                table: "Image",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Services_ServiceId",
                table: "Image",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Services_ServiceId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ServiceId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Image");
        }
    }
}
