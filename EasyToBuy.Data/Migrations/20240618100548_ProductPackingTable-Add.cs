using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductPackingTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductPacking",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductPacking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProductVariationAndRate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductPackingId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShowProductWeight = table.Column<bool>(type: "bit", nullable: false),
                    ProductWeightId = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SetAsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductVariationAndRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductVariationAndRate_tblProductPacking_ProductPackingId",
                        column: x => x.ProductPackingId,
                        principalSchema: "dbo",
                        principalTable: "tblProductPacking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProductVariationAndRate_tblProductWeight_ProductWeightId",
                        column: x => x.ProductWeightId,
                        principalSchema: "dbo",
                        principalTable: "tblProductWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProductVariationAndRate_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariationId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductImages_tblProductVariationAndRate_VariationId",
                        column: x => x.VariationId,
                        principalSchema: "dbo",
                        principalTable: "tblProductVariationAndRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductImages_VariationId",
                schema: "dbo",
                table: "tblProductImages",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductVariationAndRate_ProductId",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductVariationAndRate_ProductPackingId",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                column: "ProductPackingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductVariationAndRate_ProductWeightId",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                column: "ProductWeightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblProductVariationAndRate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblProductPacking",
                schema: "dbo");
        }
    }
}
