using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductPackingRelationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblProductPacking_PackingModeId",
                schema: "dbo",
                table: "tblProductPacking",
                column: "PackingModeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PackingModeId",
                schema: "dbo",
                table: "tblProduct",
                column: "PackingModeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_PackingModeId",
                schema: "dbo",
                table: "tblCategory",
                column: "PackingModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategory_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblCategory",
                column: "PackingModeId",
                principalSchema: "dbo",
                principalTable: "tblProductPackingMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblProduct",
                column: "PackingModeId",
                principalSchema: "dbo",
                principalTable: "tblProductPackingMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPacking_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblProductPacking",
                column: "PackingModeId",
                principalSchema: "dbo",
                principalTable: "tblProductPackingMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCategory_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPacking_tblProductPackingMode_PackingModeId",
                schema: "dbo",
                table: "tblProductPacking");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPacking_PackingModeId",
                schema: "dbo",
                table: "tblProductPacking");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_PackingModeId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblCategory_PackingModeId",
                schema: "dbo",
                table: "tblCategory");
        }
    }
}
