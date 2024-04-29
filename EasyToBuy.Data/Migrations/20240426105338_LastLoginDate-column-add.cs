using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class LastLoginDatecolumnadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblVendor");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "tblVendor",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "tblVendor");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblVendor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
