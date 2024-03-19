using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexandUniquetoColorNameandColorHexCodecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ColorHexCode",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ColorHexCode",
                table: "Colors",
                column: "ColorHexCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ColorName",
                table: "Colors",
                column: "ColorName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colors_ColorHexCode",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ColorName",
                table: "Colors");

            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ColorHexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
