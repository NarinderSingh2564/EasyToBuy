using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressUpdations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblCity_CityId",
                table: "tblAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblCountry_CountryId",
                table: "tblAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_tblAddress_tblState_StateId",
                table: "tblAddress");

           

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "tblAddress");

            migrationBuilder.RenameColumn(
                name: "ProductWeights",
                table: "tblProductWeight",
                newName: "ProductWeight");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "tblAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "tblAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeliveryAddress",
                table: "tblAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "tblAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDiscountPrice",
                table: "productDetails_Results",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "productDetails_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductWeight",
                table: "productDetails_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "productDetails_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductWeight",
                table: "productDetails_Results",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "cartDetailsByCustomerId_Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "cartDetailsByCustomerId_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductWeight",
                table: "cartDetailsByCustomerId_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductWeight",
                table: "cartDetailsByCustomerId_Results",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "IsDeliveryAddress",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "State",
                table: "tblAddress");

            migrationBuilder.DropColumn(
                name: "ProductDiscountPrice",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "ShowProductWeight",
                table: "productDetails_Results");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.DropColumn(
                name: "ShowProductWeight",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.RenameColumn(
                name: "ProductWeight",
                table: "tblProductWeight",
                newName: "ProductWeights");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "tblAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_CityId",
                table: "tblAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_CountryId",
                table: "tblAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_StateId",
                table: "tblAddress",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblCity_CityId",
                table: "tblAddress",
                column: "CityId",
                principalTable: "tblCity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblCountry_CountryId",
                table: "tblAddress",
                column: "CountryId",
                principalTable: "tblCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAddress_tblState_StateId",
                table: "tblAddress",
                column: "StateId",
                principalTable: "tblState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
