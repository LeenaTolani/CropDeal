using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigrationForCropDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CropDetails",
                newName: "QuantityInKg");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CropDetails",
                newName: "PricePerKg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityInKg",
                table: "CropDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "PricePerKg",
                table: "CropDetails",
                newName: "Price");
        }
    }
}
