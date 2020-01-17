using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubrics.Data.Access.Migrations
{
    public partial class studentrefactoredagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
