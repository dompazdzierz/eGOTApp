using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class rename_mountain_system_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MountainSystemId",
                table: "Mountain_range",
                newName: "mountain_system");

            migrationBuilder.RenameIndex(
                name: "IX_Mountain_range_MountainSystemId",
                table: "Mountain_range",
                newName: "IX_Mountain_range_mountain_system");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mountain_system",
                table: "Mountain_range",
                newName: "MountainSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Mountain_range_mountain_system",
                table: "Mountain_range",
                newName: "IX_Mountain_range_MountainSystemId");
        }
    }
}
