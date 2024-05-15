using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToBuy.Data.Migrations
{
    /// <inheritdoc />
    public partial class VendorCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendorOrdersCountById_Results",
                schema: "dbo",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveredOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorOrdersCountById_Results", x => x.VendorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vendorOrdersCountById_Results",
                schema: "dbo");
        }
    }
}
