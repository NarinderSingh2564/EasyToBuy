using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class tblproductcolumnadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductWeightId",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductWeight",
                table: "tblProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_ProductWeightId",
                table: "tblProduct",
                column: "ProductWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblProductWeight_ProductWeightId",
                table: "tblProduct",
                column: "ProductWeightId",
                principalTable: "tblProductWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblProductWeight_ProductWeightId",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_ProductWeightId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ProductWeightId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "ShowProductWeight",
                table: "tblProduct");
        }
    }
}
