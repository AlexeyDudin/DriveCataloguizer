using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveCataloguizerInfrastructure.Migrations
{
    public partial class AddPathToDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path_to_directory",
                table: "DriveInformation",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path_to_directory",
                table: "DriveInformation");
        }
    }
}
