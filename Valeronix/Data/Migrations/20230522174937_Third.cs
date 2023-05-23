using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valeronix.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "VideoCard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Processor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Mouse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "MonitorMagaz",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Keyboard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Computer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "VideoCard");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Processor");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Mouse");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "MonitorMagaz");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Computer");
        }
    }
}
