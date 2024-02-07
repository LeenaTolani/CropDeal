using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crop_Deal.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipt_CropDetails_CropDetailsCropId",
                table: "Recipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipt_Users_DealerId",
                table: "Recipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipt_Users_FarmerId",
                table: "Recipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipt",
                table: "Recipt");

            migrationBuilder.RenameTable(
                name: "Recipt",
                newName: "Receipt");

            migrationBuilder.RenameIndex(
                name: "IX_Recipt_FarmerId",
                table: "Receipt",
                newName: "IX_Receipt_FarmerId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipt_DealerId",
                table: "Receipt",
                newName: "IX_Receipt_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipt_CropDetailsCropId",
                table: "Receipt",
                newName: "IX_Receipt_CropDetailsCropId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ReciptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_CropDetails_CropDetailsCropId",
                table: "Receipt",
                column: "CropDetailsCropId",
                principalTable: "CropDetails",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Users_DealerId",
                table: "Receipt",
                column: "DealerId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Users_FarmerId",
                table: "Receipt",
                column: "FarmerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_CropDetails_CropDetailsCropId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Users_DealerId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Users_FarmerId",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Recipt");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_FarmerId",
                table: "Recipt",
                newName: "IX_Recipt_FarmerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_DealerId",
                table: "Recipt",
                newName: "IX_Recipt_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CropDetailsCropId",
                table: "Recipt",
                newName: "IX_Recipt_CropDetailsCropId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipt",
                table: "Recipt",
                column: "ReciptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipt_CropDetails_CropDetailsCropId",
                table: "Recipt",
                column: "CropDetailsCropId",
                principalTable: "CropDetails",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipt_Users_DealerId",
                table: "Recipt",
                column: "DealerId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipt_Users_FarmerId",
                table: "Recipt",
                column: "FarmerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
