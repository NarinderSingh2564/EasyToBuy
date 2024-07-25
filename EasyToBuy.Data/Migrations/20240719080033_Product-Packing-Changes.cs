using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductPackingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackingMode",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "PackingMode",
                schema: "dbo",
                table: "tblCategory");

            migrationBuilder.AddColumn<int>(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblProductPacking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "productVariationListById_Results",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tblProductPackingMode",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingMode = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductPackingMode", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductPackingMode",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblProductPacking");

            migrationBuilder.DropColumn(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "PackingModeId",
                schema: "dbo",
                table: "tblCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "productVariationListById_Results");

            migrationBuilder.AddColumn<string>(
                name: "PackingMode",
                schema: "dbo",
                table: "tblProduct",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PackingMode",
                schema: "dbo",
                table: "tblCategory",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }
    }
}
