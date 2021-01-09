using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasarman_Andra_Proiect1.Migrations
{
    public partial class Facilități : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Durata",
                table: "Vacanță",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facilități",
                table: "Hotel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facilități",
                table: "Hotel");

            migrationBuilder.AlterColumn<string>(
                name: "Durata",
                table: "Vacanță",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
