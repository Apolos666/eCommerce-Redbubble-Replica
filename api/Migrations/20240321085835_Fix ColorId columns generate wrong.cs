using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixColorIdcolumnsgeneratewrong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Colors_ColorModelId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ColorModelId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ColorModelId",
                table: "ProductItems");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ColorId",
                table: "ProductItems",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Colors_ColorId",
                table: "ProductItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Colors_ColorId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ColorId",
                table: "ProductItems");

            migrationBuilder.AddColumn<int>(
                name: "ColorModelId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ColorModelId",
                table: "ProductItems",
                column: "ColorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Colors_ColorModelId",
                table: "ProductItems",
                column: "ColorModelId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
