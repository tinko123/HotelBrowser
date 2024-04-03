using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class addingPriceToTheHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Owners_HotelOwenerId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "HotelOwenerId",
                table: "Hotels",
                newName: "HotelOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_HotelOwenerId",
                table: "Hotels",
                newName: "IX_Hotels_HotelOwnerId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Hotel's price for 1 night");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Owners_HotelOwnerId",
                table: "Hotels",
                column: "HotelOwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Owners_HotelOwnerId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "HotelOwnerId",
                table: "Hotels",
                newName: "HotelOwenerId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_HotelOwnerId",
                table: "Hotels",
                newName: "IX_Hotels_HotelOwenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Owners_HotelOwenerId",
                table: "Hotels",
                column: "HotelOwenerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }
    }
}
