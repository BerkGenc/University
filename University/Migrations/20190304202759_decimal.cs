using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Migrations
{
    public partial class @decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GPA",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GPA",
                table: "Students",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
