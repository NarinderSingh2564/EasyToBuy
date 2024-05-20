using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class TblCustomerOrderStatusLogCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "dbo",
                table: "orderList_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblCustomerOrderStatusLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerOrderStatusLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalSchema: "dbo",
                        principalTable: "tblCustomerOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblCustomerOrderStatusLog_tblOrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalSchema: "dbo",
                        principalTable: "tblOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomerOrderStatusLog",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                schema: "dbo",
                table: "orderList_Results");
        }
    }
}
