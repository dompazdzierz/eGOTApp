using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class add_photoproof_and_fix_its_ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo_proof",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_trip = table.Column<int>(nullable: false),
                    photo_url = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo_proof", x => x.id);
                    table.ForeignKey(
                        name: "FKPhoto_proof12437",
                        column: x => x.id_trip,
                        principalTable: "Trip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Photo_proof_id",
                table: "Photo_proof",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_proof_id_trip",
                table: "Photo_proof",
                column: "id_trip",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo_proof");
        }
    }
}
