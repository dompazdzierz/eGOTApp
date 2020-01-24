using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class add_trip_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Trip",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "Trip");
        }
    }
}
