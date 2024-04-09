using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class producttableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceAfterDiscount",
                table: "tblProduct",
                newName: "ProductPriceAfterDiscount");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountPrice",
                table: "tblProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "productDetails_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTimeSpan",
                table: "cartDetailsByCustomerId_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "cartDetailsByCustomerId_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductDiscount",
                table: "cartDetailsByCustomerId_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountPrice",
                table: "cartDetailsByCustomerId_Results",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPriceAfterDiscount",
                table: "cartDetailsByCustomerId_Results",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDiscountPrice",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "DeliveryTimeSpan",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductDiscount",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductDiscountPrice",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductPriceAfterDiscount",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.RenameColumn(
                name: "ProductPriceAfterDiscount",
                table: "tblProduct",
                newName: "PriceAfterDiscount");
        }
    }
}
