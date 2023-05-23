using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valeronix.Migrations
{
    /// <inheritdoc />
    public partial class eleven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Memory",
                table: "Computer",
                newName: "MemoryVolume");

            migrationBuilder.AddColumn<string>(
                name: "MemoryType",
                table: "Computer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemoryType",
                table: "Computer");

            migrationBuilder.RenameColumn(
                name: "MemoryVolume",
                table: "Computer",
                newName: "Memory");
        }
    }
}
