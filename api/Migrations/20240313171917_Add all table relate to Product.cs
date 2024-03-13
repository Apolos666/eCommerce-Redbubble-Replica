using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddalltablerelatetoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeCategoryId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ColorModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItems_Colors_ColorModelId",
                        column: x => x.ColorModelId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeOptionName = table.Column<int>(type: "int", nullable: false),
                    ProductAttributeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeOptions_ProductAttributeTypes_ProductAttributeTypeId",
                        column: x => x.ProductAttributeTypeId,
                        principalTable: "ProductAttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    SizeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeOptions_SizeCategories_SizeCategoryId",
                        column: x => x.SizeCategoryId,
                        principalTable: "SizeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAttributeOptionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => new { x.ProductId, x.ProductAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_ProductAttributes_ProductAttributeOptions_ProductAttributeOptionId",
                        column: x => x.ProductAttributeOptionId,
                        principalTable: "ProductAttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizeVariations",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    SizeOptionsId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeVariations", x => new { x.ProductItemId, x.SizeOptionsId });
                    table.ForeignKey(
                        name: "FK_ProductSizeVariations_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizeVariations_SizeOptions_SizeOptionsId",
                        column: x => x.SizeOptionsId,
                        principalTable: "SizeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_SizeCategoryId",
                table: "ProductCategories",
                column: "SizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeOptions_ProductAttributeTypeId",
                table: "ProductAttributeOptions",
                column: "ProductAttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductAttributeOptionId",
                table: "ProductAttributes",
                column: "ProductAttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ColorModelId",
                table: "ProductItems",
                column: "ColorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductId",
                table: "ProductItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeVariations_SizeOptionsId",
                table: "ProductSizeVariations",
                column: "SizeOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeOptions_SizeCategoryId",
                table: "SizeOptions",
                column: "SizeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_SizeCategories_SizeCategoryId",
                table: "ProductCategories",
                column: "SizeCategoryId",
                principalTable: "SizeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_SizeCategories_SizeCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSizeVariations");

            migrationBuilder.DropTable(
                name: "ProductAttributeOptions");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "SizeOptions");

            migrationBuilder.DropTable(
                name: "ProductAttributeTypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "SizeCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_SizeCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "SizeCategoryId",
                table: "ProductCategories");
        }
    }
}
