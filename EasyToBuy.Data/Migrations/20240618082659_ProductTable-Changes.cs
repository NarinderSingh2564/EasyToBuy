using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblProductWeight_ProductWeightId",
                schema: "dbo",
                table: "tblProduct");

           

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_ProductWeightId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "MRP",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "PriceAfterDiscount",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductWeightId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ShowProductWeight",
                schema: "dbo",
                table: "tblProduct");

          

         

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "vendorOrdersCountById_Results");

            migrationBuilder.DropColumn(
                name: "IconClass",
                schema: "dbo",
                table: "vendorOrdersCountById_Results");

           

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                schema: "dbo",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                schema: "dbo",
                table: "tblProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MRP",
                schema: "dbo",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAfterDiscount",
                schema: "dbo",
                table: "tblProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductWeightId",
                schema: "dbo",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductWeight",
                schema: "dbo",
                table: "tblProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

        

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_ProductWeightId",
                schema: "dbo",
                table: "tblProduct",
                column: "ProductWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblProductWeight_ProductWeightId",
                schema: "dbo",
                table: "tblProduct",
                column: "ProductWeightId",
                principalSchema: "dbo",
                principalTable: "tblProductWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
