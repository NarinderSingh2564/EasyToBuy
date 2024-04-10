using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class productweight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceAfterDiscount",
                table: "productDetails_Results",
                newName: "ProductPriceAfterDiscount");

            migrationBuilder.RenameColumn(
                name: "DeliveryTimeSpan",
                table: "cartDetailsByCustomerId_Results",
                newName: "ProductTimeSpan");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProductPrice",
                table: "cartDetailsByCustomerId_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "tblProductWeight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductWeight = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductWeight", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductWeight");

            migrationBuilder.RenameColumn(
                name: "ProductPriceAfterDiscount",
                table: "productDetails_Results",
                newName: "PriceAfterDiscount");

            migrationBuilder.RenameColumn(
                name: "ProductTimeSpan",
                table: "cartDetailsByCustomerId_Results",
                newName: "DeliveryTimeSpan");

            migrationBuilder.AlterColumn<int>(
                name: "TotalProductPrice",
                table: "cartDetailsByCustomerId_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
