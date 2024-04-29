using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class vendortablechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "tblVendor");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "tblVendor");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblVendor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusRemarks",
                table: "tblVendor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblVendor");

            migrationBuilder.DropColumn(
                name: "StatusRemarks",
                table: "tblVendor");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "tblVendor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "tblVendor",
                type: "bit",
                nullable: true);
        }
    }
}
