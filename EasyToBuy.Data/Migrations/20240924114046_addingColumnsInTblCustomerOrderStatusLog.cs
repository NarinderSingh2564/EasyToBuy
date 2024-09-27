using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingColumnsInTblCustomerOrderStatusLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                newName: "VendorId");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "productDetailsByOrderNumberAndUserId_Result",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountToBePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDetailsByOrderNumberAndUserId_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userOrdersListByUserId_Result",
                schema: "dbo",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOrdersListByUserId_Result", x => x.OrderNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productDetailsByOrderNumberAndUserId_Result",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "userOrdersListByUserId_Result",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "tblCustomerOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
