using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_CropTypes_CropTypeId",
                table: "Subscribes");

            migrationBuilder.DropIndex(
                name: "IX_Subscribes_CropTypeId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "CropTypeId",
                table: "Subscribes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CropTypeId",
                table: "Subscribes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_CropTypeId",
                table: "Subscribes",
                column: "CropTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_CropTypes_CropTypeId",
                table: "Subscribes",
                column: "CropTypeId",
                principalTable: "CropTypes",
                principalColumn: "CropTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
