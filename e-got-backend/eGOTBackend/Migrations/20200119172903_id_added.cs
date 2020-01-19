using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class id_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKHistory784901",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FKTrip848043",
                table: "Trip");

            migrationBuilder.DropTable(
                name: "Turist");

            migrationBuilder.DropIndex(
                name: "IX_Trip_id_turist",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK__History__2A509D270486FE06",
                table: "History");

            migrationBuilder.DropColumn(
                name: "id_turist",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "id_turist",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "id_tourist",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Route",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Photo_proof",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Permission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Leader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_tourist",
                table: "History",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "History",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GPS_proof",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Department_worker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Commission_worker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__History__2A509D270486FE06",
                table: "History",
                columns: new[] { "id_tourist", "id_badge_level" });

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_disabled = table.Column<bool>(nullable: false),
                    all_points = table.Column<int>(nullable: false),
                    confirmed_points = table.Column<int>(nullable: false),
                    id_badge_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tourist__D2D1463735CD9327", x => x.id_user);
                    table.ForeignKey(
                        name: "FKTourist324263",
                        column: x => x.id_badge_level,
                        principalTable: "Badge_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTourist733992",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_id_tourist",
                table: "Trip",
                column: "id_tourist");

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_id_badge_level",
                table: "Tourist",
                column: "id_badge_level");

            migrationBuilder.AddForeignKey(
                name: "FKHistory784901",
                table: "History",
                column: "id_tourist",
                principalTable: "Tourist",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FKTrip848043",
                table: "Trip",
                column: "id_tourist",
                principalTable: "Tourist",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKHistory784901",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FKTrip848043",
                table: "Trip");

            migrationBuilder.DropTable(
                name: "Tourist");

            migrationBuilder.DropIndex(
                name: "IX_Trip_id_tourist",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK__History__2A509D270486FE06",
                table: "History");

            migrationBuilder.DropColumn(
                name: "id_tourist",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Photo_proof");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Leader");

            migrationBuilder.DropColumn(
                name: "id_tourist",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GPS_proof");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Department_worker");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Commission_worker");

            migrationBuilder.AddColumn<int>(
                name: "id_turist",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_turist",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__History__2A509D270486FE06",
                table: "History",
                columns: new[] { "id_turist", "id_badge_level" });

            migrationBuilder.CreateTable(
                name: "Turist",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    all_points = table.Column<int>(type: "int", nullable: false),
                    confirmed_points = table.Column<int>(type: "int", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_badge_level = table.Column<int>(type: "int", nullable: false),
                    is_disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turist__D2D1463735CD9327", x => x.id_user);
                    table.ForeignKey(
                        name: "FKTurist324263",
                        column: x => x.id_badge_level,
                        principalTable: "Badge_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKTurist733992",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_id_turist",
                table: "Trip",
                column: "id_turist");

            migrationBuilder.CreateIndex(
                name: "IX_Turist_id_badge_level",
                table: "Turist",
                column: "id_badge_level");

            migrationBuilder.AddForeignKey(
                name: "FKHistory784901",
                table: "History",
                column: "id_turist",
                principalTable: "Turist",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FKTrip848043",
                table: "Trip",
                column: "id_turist",
                principalTable: "Turist",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
