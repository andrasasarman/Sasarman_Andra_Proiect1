using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasarman_Andra_Proiect1.Migrations
{
    public partial class Vacanță : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacanță",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinație = table.Column<string>(maxLength: 50, nullable: false),
                    Plecare = table.Column<string>(maxLength: 150, nullable: false),
                    Preț = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Durata = table.Column<string>(nullable: true),
                    NrPers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacanță", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacanță");
        }
    }
}
