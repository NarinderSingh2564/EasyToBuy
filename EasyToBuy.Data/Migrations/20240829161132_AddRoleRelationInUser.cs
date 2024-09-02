using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleRelationInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "dbo",
                table: "tblUser",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_RoleId",
                schema: "dbo",
                table: "tblUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblRole_RoleId",
                schema: "dbo",
                table: "tblUser",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblRole_RoleId",
                schema: "dbo",
                table: "tblUser");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_RoleId",
                schema: "dbo",
                table: "tblUser");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "dbo",
                table: "tblUser",
                newName: "Role");
        }
    }
}
