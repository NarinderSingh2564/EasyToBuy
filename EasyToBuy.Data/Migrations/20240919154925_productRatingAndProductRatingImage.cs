using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class productRatingAndProductRatingImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductRating",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewTitle = table.Column<string>(type: "varchar(30)", nullable: false),
                    ReviewDescription = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductRating_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductRatingImages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductRatingId = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductRatingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductRatingImages_tblProductRating_ProductRatingId",
                        column: x => x.ProductRatingId,
                        principalSchema: "dbo",
                        principalTable: "tblProductRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductRating_ProductId",
                schema: "dbo",
                table: "tblProductRating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductRatingImages_ProductRatingId",
                schema: "dbo",
                table: "tblProductRatingImages",
                column: "ProductRatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductRatingImages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblProductRating",
                schema: "dbo");
        }
    }
}
