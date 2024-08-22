using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class tblusertotblcustomer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                schema: "dbo",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblUser",
                schema: "dbo",
                newName: "tblCustomer",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCustomer",
                schema: "dbo",
                table: "tblCustomer",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCustomer",
                schema: "dbo",
                table: "tblCustomer");

            migrationBuilder.RenameTable(
                name: "tblCustomer",
                schema: "dbo",
                newName: "tblUser",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                schema: "dbo",
                table: "tblUser",
                column: "Id");
        }
    }
}
