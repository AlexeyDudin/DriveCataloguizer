using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveCataloguizerInfrastructure.Migrations
{
    public partial class AddDriveDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "drive_description",
                table: "DriveInformation",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drive_description",
                table: "DriveInformation");
        }
    }
}
