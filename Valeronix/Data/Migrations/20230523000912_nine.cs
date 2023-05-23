using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valeronix.Migrations
{
    /// <inheritdoc />
    public partial class nine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MonitorMagaz",
                newName: "TypeOfMonitor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfMonitor",
                table: "MonitorMagaz",
                newName: "Type");
        }
    }
}
