using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valeronix.Migrations
{
    /// <inheritdoc />
    public partial class Chet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_TypeOfDevice_TypeOfDeviceId",
                table: "Computer");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyboard_TypeOfDevice_TypeOfDeviceId",
                table: "Keyboard");

            migrationBuilder.DropForeignKey(
                name: "FK_MonitorMagaz_TypeOfDevice_TypeOfDeviceId",
                table: "MonitorMagaz");

            migrationBuilder.DropForeignKey(
                name: "FK_Mouse_TypeOfDevice_TypeOfDeviceId",
                table: "Mouse");

            migrationBuilder.DropTable(
                name: "TypeOfDevice");

            migrationBuilder.DropIndex(
                name: "IX_Mouse_TypeOfDeviceId",
                table: "Mouse");

            migrationBuilder.DropIndex(
                name: "IX_MonitorMagaz_TypeOfDeviceId",
                table: "MonitorMagaz");

            migrationBuilder.DropIndex(
                name: "IX_Keyboard_TypeOfDeviceId",
                table: "Keyboard");

            migrationBuilder.DropIndex(
                name: "IX_Computer_TypeOfDeviceId",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "TypeOfDeviceId",
                table: "Mouse");

            migrationBuilder.DropColumn(
                name: "TypeOfDeviceId",
                table: "MonitorMagaz");

            migrationBuilder.DropColumn(
                name: "TypeOfDeviceId",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "TypeOfDeviceId",
                table: "Computer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfDeviceId",
                table: "Mouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDeviceId",
                table: "MonitorMagaz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDeviceId",
                table: "Keyboard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Computer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDeviceId",
                table: "Computer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOfDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDevice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mouse_TypeOfDeviceId",
                table: "Mouse",
                column: "TypeOfDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorMagaz_TypeOfDeviceId",
                table: "MonitorMagaz",
                column: "TypeOfDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboard_TypeOfDeviceId",
                table: "Keyboard",
                column: "TypeOfDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_TypeOfDeviceId",
                table: "Computer",
                column: "TypeOfDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_TypeOfDevice_TypeOfDeviceId",
                table: "Computer",
                column: "TypeOfDeviceId",
                principalTable: "TypeOfDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyboard_TypeOfDevice_TypeOfDeviceId",
                table: "Keyboard",
                column: "TypeOfDeviceId",
                principalTable: "TypeOfDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonitorMagaz_TypeOfDevice_TypeOfDeviceId",
                table: "MonitorMagaz",
                column: "TypeOfDeviceId",
                principalTable: "TypeOfDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mouse_TypeOfDevice_TypeOfDeviceId",
                table: "Mouse",
                column: "TypeOfDeviceId",
                principalTable: "TypeOfDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
