using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBrowser.Infrastructure.Migrations
{
    public partial class TableHotelsAndWorkCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "WorkCategory id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "WorkCategory name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Hotel id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Hotel name"),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Hotel receptionis's phone fo booking"),
                    WorkCategoryId = table.Column<int>(type: "int", nullable: false, comment: "WorkCategory identifier"),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Owner of the hotel"),
                    FreeRooms = table.Column<int>(type: "int", nullable: false, comment: "How many rooms are free to use"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Hotel's description"),
                    Location = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Hotel's location"),
                    Image = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Hotel's image url"),
                    OwenerId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Hotel's owner identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_WorkCategories_WorkCategoryId",
                        column: x => x.WorkCategoryId,
                        principalTable: "WorkCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_WorkCategoryId",
                table: "Hotels",
                column: "WorkCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "WorkCategories");
        }
    }
}
