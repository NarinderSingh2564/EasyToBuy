using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorCode",
                schema: "dbo",
                table: "tblUser",
                newName: "UserCode");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "tblUser",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblUserBankDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "dbo",
                table: "tblCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "dbo",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserCompanyDetails_UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserBankDetails_UserId",
                schema: "dbo",
                table: "tblUserBankDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_UserId",
                schema: "dbo",
                table: "tblProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrder_CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_CustomerId",
                schema: "dbo",
                table: "tblCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_CustomerId",
                schema: "dbo",
                table: "tblAddress",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblAddress",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "tblCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCart_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblCart",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "tblCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrder_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "tblCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblUser_UserId",
                schema: "dbo",
                table: "tblProduct",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserBankDetails_tblUser_UserId",
                schema: "dbo",
                table: "tblUserBankDetails",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserCompanyDetails_tblUser_UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCart_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblCustomer_CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblUser_UserId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserBankDetails_tblUser_UserId",
                schema: "dbo",
                table: "tblUserBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserCompanyDetails_tblUser_UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails");

            migrationBuilder.DropIndex(
                name: "IX_tblUserCompanyDetails_UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails");

            migrationBuilder.DropIndex(
                name: "IX_tblUserBankDetails_UserId",
                schema: "dbo",
                table: "tblUserBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_UserId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrder_CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_tblCart_CustomerId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropIndex(
                name: "IX_tblAddress_CustomerId",
                schema: "dbo",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblUserCompanyDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblUserBankDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "tblAddress");

            migrationBuilder.RenameColumn(
                name: "UserCode",
                schema: "dbo",
                table: "tblUser",
                newName: "VendorCode");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "dbo",
                table: "tblUser",
                newName: "Type");
        }
    }
}
