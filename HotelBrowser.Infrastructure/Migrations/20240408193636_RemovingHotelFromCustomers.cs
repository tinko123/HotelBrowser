using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class RemovingHotelFromCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_HotelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HotelId",
                table: "Customers",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_HotelId",
                table: "Customers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
