using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class InitialMigration2 : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Hotel's cumtomer");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CustomerId",
                table: "Hotels",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_CustomerId",
                table: "Hotels",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_CustomerId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CustomerId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Hotels");

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
