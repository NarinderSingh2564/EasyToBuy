using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVariationIdColumnInCustomerStatusLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusDate",
                schema: "dbo",
                table: "getTrackingStatusListByOrderId_Results",
                newName: "statusDate");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewDescription",
                schema: "dbo",
                table: "tblProductRating",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddColumn<int>(
                name: "VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerOrderStatusLog_VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "VariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog",
                column: "VariationId",
                principalSchema: "dbo",
                principalTable: "tblProductVariationAndRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCustomerOrderStatusLog_tblProductVariationAndRate_VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_tblCustomerOrderStatusLog_VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.DropColumn(
                name: "VariationId",
                schema: "dbo",
                table: "tblCustomerOrderStatusLog");

            migrationBuilder.RenameColumn(
                name: "statusDate",
                schema: "dbo",
                table: "getTrackingStatusListByOrderId_Results",
                newName: "StatusDate");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewDescription",
                schema: "dbo",
                table: "tblProductRating",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);
        }
    }
}
