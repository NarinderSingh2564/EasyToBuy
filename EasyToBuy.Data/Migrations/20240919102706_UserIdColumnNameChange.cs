using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserIdColumnNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblUser_UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCustomerOrder_UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "IX_tblCustomerOrder_VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblUser_VendorId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "VendorId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblUser_VendorId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCustomerOrder_VendorId",
                schema: "dbo",
                table: "tblCustomerOrder",
                newName: "IX_tblCustomerOrder_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblUser_UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
