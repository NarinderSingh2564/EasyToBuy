using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class producttablechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductShortName",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductSku",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductTimeSpan",
                table: "tblProduct");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "tblProduct",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "tblProduct",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "tblProduct");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "tblProduct",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "tblProduct",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductShortName",
                table: "tblProduct",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductSku",
                table: "tblProduct",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductTimeSpan",
                table: "tblProduct",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
