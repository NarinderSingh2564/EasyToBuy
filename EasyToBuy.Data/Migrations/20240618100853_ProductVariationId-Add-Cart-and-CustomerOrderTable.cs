using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductVariationIdAddCartandCustomerOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCart_tblProduct_ProductId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblProduct_ProductId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "VariationId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCustomerOrder_ProductId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "IX_tblCustomerOrder_VariationId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "tblCart",
                newName: "VariationId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCart_ProductId",
                schema: "dbo",
                table: "tblCart",
                newName: "IX_tblCart_VariationId");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCart_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCart",
                column: "VariationId",
                principalSchema: "dbo",
                principalTable: "tblProductVariationAndRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "VariationId",
                principalSchema: "dbo",
                principalTable: "tblProductVariationAndRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCart_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.RenameColumn(
                name: "VariationId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCustomerOrder_VariationId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "IX_tblCustomerOrder_ProductId");

            migrationBuilder.RenameColumn(
                name: "VariationId",
                schema: "dbo",
                table: "tblCart",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCart_VariationId",
                schema: "dbo",
                table: "tblCart",
                newName: "IX_tblCart_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "MRP",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCart_tblProduct_ProductId",
                schema: "dbo",
                table: "tblCart",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblProduct_ProductId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
