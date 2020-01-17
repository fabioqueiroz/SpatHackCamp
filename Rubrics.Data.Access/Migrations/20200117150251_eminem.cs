using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubrics.Data.Access.Migrations
{
    public partial class eminem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TableGroupStudents");

            migrationBuilder.AddColumn<int>(
                name: "TableGroupId",
                table: "TableGroupStudents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableGroupId",
                table: "TableGroupStudents");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TableGroupStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
