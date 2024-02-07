using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_CropDetails_CropDetailsCropId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_CropDetailsCropId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "CropDetailsCropId",
                table: "Receipt");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CropId",
                table: "Receipt",
                column: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_CropDetails_CropId",
                table: "Receipt",
                column: "CropId",
                principalTable: "CropDetails",
                principalColumn: "CropId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_CropDetails_CropId",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_CropId",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "CropDetailsCropId",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CropDetailsCropId",
                table: "Receipt",
                column: "CropDetailsCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_CropDetails_CropDetailsCropId",
                table: "Receipt",
                column: "CropDetailsCropId",
                principalTable: "CropDetails",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
