using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnaddresstype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_AddressTypeId",
                table: "tblAddress",
                column: "AddressTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblAddressType_AddressTypeId",
                table: "tblAddress",
                column: "AddressTypeId",
                principalTable: "tblAddressType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblAddressType_AddressTypeId",
                table: "tblAddress");

            migrationBuilder.DropIndex(
                name: "IX_tblAddress_AddressTypeId",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "tblAddress");
        }
    }
}
