using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class FixingTheNameHotelIdMakingItWithCapital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_hotelId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "hotelId",
                table: "Customers",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_hotelId",
                table: "Customers",
                newName: "IX_Customers_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Customers",
                newName: "hotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_HotelId",
                table: "Customers",
                newName: "IX_Customers_hotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_hotelId",
                table: "Customers",
                column: "hotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
