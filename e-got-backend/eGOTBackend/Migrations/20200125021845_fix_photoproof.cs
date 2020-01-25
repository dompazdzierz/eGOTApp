using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class fix_photoproof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKPhoto_proof12437",
                table: "Photo_proof");

            migrationBuilder.DropIndex(
                name: "IX_Photo_proof_id_trip",
                table: "Photo_proof");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_proof_id_trip",
                table: "Photo_proof",
                column: "id_trip");

            migrationBuilder.AddForeignKey(
                name: "FKSection199844",
                table: "Photo_proof",
                column: "id_trip",
                principalTable: "Trip",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKSection199844",
                table: "Photo_proof");

            migrationBuilder.DropIndex(
                name: "IX_Photo_proof_id_trip",
                table: "Photo_proof");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_proof_id_trip",
                table: "Photo_proof",
                column: "id_trip",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FKPhoto_proof12437",
                table: "Photo_proof",
                column: "id_trip",
                principalTable: "Trip",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
