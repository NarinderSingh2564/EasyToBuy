using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class weightvaluecolumnadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductWeightValue",
                schema: "dbo",
                table: "tblProductWeight",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVolume",
                schema: "dbo",
                table: "productList_Results",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductWeightValue",
                schema: "dbo",
                table: "tblProductWeight");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                schema: "dbo",
                table: "productList_Results");
        }
    }
}
