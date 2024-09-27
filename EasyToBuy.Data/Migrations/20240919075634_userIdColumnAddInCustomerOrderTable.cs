using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class userIdColumnAddInCustomerOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrder_UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblUser_UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblUser_UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrder_UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                schema: "dbo",
                table: "orderList_Results",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
