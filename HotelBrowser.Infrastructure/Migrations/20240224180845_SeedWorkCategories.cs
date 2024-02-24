using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class SeedWorkCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "All year" });

            migrationBuilder.InsertData(
                table: "WorkCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Summer" });

            migrationBuilder.InsertData(
                table: "WorkCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Winter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
