using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class add_mountain_system_fk_to_mountain_ranges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mountain_range_Mountain_system_MountainSystemId",
                table: "Mountain_range");

            migrationBuilder.AlterColumn<int>(
                name: "MountainSystemId",
                table: "Mountain_range",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FKSection521451",
                table: "Mountain_range",
                column: "MountainSystemId",
                principalTable: "Mountain_system",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKSection521451",
                table: "Mountain_range");

            migrationBuilder.AlterColumn<int>(
                name: "MountainSystemId",
                table: "Mountain_range",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Mountain_range_Mountain_system_MountainSystemId",
                table: "Mountain_range",
                column: "MountainSystemId",
                principalTable: "Mountain_system",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
