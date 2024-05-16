using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class abcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "orderList_Results",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "ProductWeight",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductWeight",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "orderList_Results",
                newName: "CustomerId");
        }
    }
}
