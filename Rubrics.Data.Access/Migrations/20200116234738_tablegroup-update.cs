using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubrics.Data.Access.Migrations
{
    public partial class tablegroupupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableGroupName",
                table: "TableGroups");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "TableGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TableGroups",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TableGroups");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TableGroups");

            migrationBuilder.AddColumn<int>(
                name: "TableGroupName",
                table: "TableGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
