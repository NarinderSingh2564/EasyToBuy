using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class columnchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCode",
                schema: "dbo",
                table: "tblUser");

            migrationBuilder.AddColumn<int>(
                name: "VariationId",
                schema: "dbo",
                table: "orderList_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariationId",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                schema: "dbo",
                table: "tblUser",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
