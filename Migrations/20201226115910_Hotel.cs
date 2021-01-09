using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasarman_Andra_Proiect1.Migrations
{
    public partial class Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelID",
                table: "Vacanță",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacanță_HotelID",
                table: "Vacanță",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacanță_Hotel_HotelID",
                table: "Vacanță",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacanță_Hotel_HotelID",
                table: "Vacanță");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Vacanță_HotelID",
                table: "Vacanță");

            migrationBuilder.DropColumn(
                name: "HotelID",
                table: "Vacanță");
        }
    }
}
