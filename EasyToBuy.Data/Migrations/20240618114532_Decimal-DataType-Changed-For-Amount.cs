using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class DecimalDataTypeChangedForAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAfterDiscount",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountToBePaid",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "Decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAfterDiscount",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountToBePaid",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(7,2)");
        }
    }
}
