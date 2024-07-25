using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class isDeletecolumnaddinvariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ISDeleted",
                schema: "dbo",
                table: "tblProductVariationAndRate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductWeightValue",
                schema: "dbo",
                table: "productVariationListById_Results",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISDeleted",
                schema: "dbo",
                table: "tblProductVariationAndRate");

            migrationBuilder.DropColumn(
                name: "ProductWeightValue",
                schema: "dbo",
                table: "productVariationListById_Results");
        }
    }
}
