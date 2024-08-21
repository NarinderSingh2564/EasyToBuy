using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class tblusertotblcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblUser_UserId",
                schema: "dbo",
                table: "tblAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCart_tblUser_UserId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrder_tblUser_UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrder_UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_tblCart_UserId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropIndex(
                name: "IX_tblAddress_UserId",
                schema: "dbo",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblCustomerOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "tblAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrder_UserId",
                schema: "dbo",
                table: "tblCustomerOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                schema: "dbo",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_UserId",
                schema: "dbo",
                table: "tblAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblUser_UserId",
                schema: "dbo",
                table: "tblAddress",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCart_tblUser_UserId",
                schema: "dbo",
                table: "tblCart",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
