using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveCataloguizerInfrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogueInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number = table.Column<string>(type: "TEXT", nullable: true),
                    capacity = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    number = table.Column<string>(type: "TEXT", nullable: true),
                    second_number = table.Column<string>(type: "TEXT", nullable: true),
                    drive_type = table.Column<int>(type: "INTEGER", nullable: false),
                    drive_status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogueToDriveInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CatalogueId = table.Column<long>(type: "INTEGER", nullable: false),
                    DriveId = table.Column<long>(type: "INTEGER", nullable: false),
                    drive_position = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueToDriveInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogueToDriveInformation_CatalogueInformation_CatalogueId",
                        column: x => x.CatalogueId,
                        principalTable: "CatalogueInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogueToDriveInformation_DriveInformation_DriveId",
                        column: x => x.DriveId,
                        principalTable: "DriveInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueToDriveInformation_CatalogueId",
                table: "CatalogueToDriveInformation",
                column: "CatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueToDriveInformation_DriveId",
                table: "CatalogueToDriveInformation",
                column: "DriveId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogueToDriveInformation");

            migrationBuilder.DropTable(
                name: "CatalogueInformation");

            migrationBuilder.DropTable(
                name: "DriveInformation");
        }
    }
}
