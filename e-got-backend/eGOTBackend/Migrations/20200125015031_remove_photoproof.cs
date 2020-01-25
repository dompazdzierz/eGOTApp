using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class remove_photoproof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo_proof");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo_proof",
                columns: table => new
                {
                    id_trip = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    photo_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Photo_pr__F5F2277824A7906D", x => x.id_trip);
                    table.ForeignKey(
                        name: "FKPhoto_proof12437",
                        column: x => x.id_trip,
                        principalTable: "Trip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
