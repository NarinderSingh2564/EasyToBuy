using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleRelationInCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "dbo",
                table: "tblCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_RoleId",
                schema: "dbo",
                table: "tblCustomer",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomer_tblRole_RoleId",
                schema: "dbo",
                table: "tblCustomer",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomer_tblRole_RoleId",
                schema: "dbo",
                table: "tblCustomer");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomer_RoleId",
                schema: "dbo",
                table: "tblCustomer");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "dbo",
                table: "tblCustomer");
        }
    }
}
