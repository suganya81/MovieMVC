using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    public partial class UpdateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryName",
                value: "Comedy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryName",
                value: "Commedy");
        }
    }
}
