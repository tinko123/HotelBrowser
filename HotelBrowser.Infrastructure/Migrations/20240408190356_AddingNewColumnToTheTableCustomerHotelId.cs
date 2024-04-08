using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class AddingNewColumnToTheTableCustomerHotelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hotelId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_hotelId",
                table: "Customers",
                column: "hotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Hotels_hotelId",
                table: "Customers",
                column: "hotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Hotels_hotelId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_hotelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "hotelId",
                table: "Customers");
        }
    }
}
