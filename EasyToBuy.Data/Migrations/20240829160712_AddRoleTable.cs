using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vendorOrdersCountById_Results",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                schema: "dbo",
                table: "productList_Results",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "dbo",
                table: "productList_Results",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                schema: "dbo",
                table: "orderList_Results",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "dbo",
                table: "orderList_Results",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                schema: "dbo",
                table: "tblUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                schema: "dbo",
                table: "tblCustomer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedirectTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userOrdersCountById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOrdersCountById_Results", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "userOrdersCountById_Results",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                schema: "dbo",
                table: "tblCustomer");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "dbo",
                table: "productList_Results",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "productList_Results",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                schema: "dbo",
                table: "orderList_Results",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "orderList_Results",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                newName: "VendorName");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "dbo",
                table: "tblUser",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "vendorOrdersCountById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorOrdersCountById_Results", x => x.Id);
                });
        }
    }
}
