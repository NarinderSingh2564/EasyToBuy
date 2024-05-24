using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class VendorDashBoardCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results");

            migrationBuilder.DropColumn(
                name: "DeliveredOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "TotalOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "OrderStatusId");

            migrationBuilder.RenameColumn(
                name: "PendingOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "OrderCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderStatusId",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "TotalOrder");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "OrderCount",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                newName: "PendingOrder");

            migrationBuilder.AddColumn<int>(
                name: "CancelOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveredOrder",
                schema: "dbo",
                table: "vendorOrdersCountById_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
