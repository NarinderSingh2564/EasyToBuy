using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class TblCustomerOrderStatusLogCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblOrderStatus_OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropColumn(
                name: "CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_StatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "tblCustomerOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblOrderStatus_StatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "tblOrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblOrderStatus_StatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_OrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_StatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.AddColumn<int>(
                name: "CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblCustomerOrder_CustomerOrderId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "CustomerOrderId",
                principalSchema: "dbo",
                principalTable: "tblCustomerOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblOrderStatus_OrderStatusId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "OrderStatusId",
                principalSchema: "dbo",
                principalTable: "tblOrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
