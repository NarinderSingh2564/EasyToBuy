using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class vendorIdcolumnadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_VendorId",
                table: "tblProduct",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblVendor_VendorId",
                table: "tblProduct",
                column: "VendorId",
                principalTable: "tblVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblVendor_VendorId",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_VendorId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "tblProduct");
        }
    }
}
