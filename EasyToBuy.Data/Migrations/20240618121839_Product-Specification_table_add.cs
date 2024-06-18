using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductSpecificationtableadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductSpecification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Speciality = table.Column<string>(type: "varchar(150)", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(50)", nullable: false),
                    IngredientType = table.Column<string>(type: "varchar(30)", nullable: false),
                    Ingredients = table.Column<string>(type: "varchar(150)", nullable: false),
                    ShelfLife = table.Column<string>(type: "varchar(50)", nullable: false),
                    Benefits = table.Column<string>(type: "varchar(250)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductSpecification_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductSpecification_ProductId",
                schema: "dbo",
                table: "tblProductSpecification",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductSpecification",
                schema: "dbo");
        }
    }
}
