using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class productListSPChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productDetailsById_Results",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "ProductWeightId",
                schema: "dbo",
                table: "productList_Results",
                newName: "VariationId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                newName: "VariationId");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "productList_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "productList_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                schema: "dbo",
                table: "productList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "orderList_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "orderList_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PackingType",
                schema: "dbo",
                table: "orderList_Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "MRP",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "SetAsDefault",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "productDescriptionById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariationId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDescriptionById_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productSpecificationById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelfLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSpecificationById_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productVariationImageById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariationImageById_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productVariationListById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPackingId = table.Column<int>(type: "int", nullable: false),
                    PackingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductWeightId = table.Column<int>(type: "int", nullable: false),
                    ProductWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ShowProductWeight = table.Column<bool>(type: "bit", nullable: false),
                    SetAsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariationListById_Results", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productDescriptionById_Results",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "productSpecificationById_Results",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "productVariationImageById_Results",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "productVariationListById_Results",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "VendorName",
                schema: "dbo",
                table: "productList_Results");

            migrationBuilder.DropColumn(
                name: "PackingType",
                schema: "dbo",
                table: "orderList_Results");

            migrationBuilder.DropColumn(
                name: "SetAsDefault",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results");

            migrationBuilder.RenameColumn(
                name: "VariationId",
                schema: "dbo",
                table: "productList_Results",
                newName: "ProductWeightId");

            migrationBuilder.RenameColumn(
                name: "VariationId",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "MRP",
                schema: "dbo",
                table: "productList_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                schema: "dbo",
                table: "productList_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MRP",
                schema: "dbo",
                table: "orderList_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                schema: "dbo",
                table: "orderList_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MRP",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                schema: "dbo",
                table: "cartDetailsByCustomerId_Results",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "productDetailsById_Results",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<int>(type: "int", nullable: false),
                    PackingMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShowProductWeight = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDetailsById_Results", x => x.Id);
                });
        }
    }
}
