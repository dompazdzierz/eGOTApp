using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class mountainsystemadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badge_level",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    required_points = table.Column<int>(nullable: false),
                    icon = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge_level", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    longtitude = table.Column<float>(nullable: false),
                    latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mountain_system",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountain_system", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    last_seen = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mountain_range",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    MountainSystemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountain_range", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mountain_range_Mountain_system_MountainSystemId",
                        column: x => x.MountainSystemId,
                        principalTable: "Mountain_system",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commission_worker",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Commissi__D2D146379EBC1A27", x => x.id_user);
                    table.ForeignKey(
                        name: "FKCommission_worker228672",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department_worker",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__D2D1463721266F09", x => x.id_user);
                    table.ForeignKey(
                        name: "FKDepartment_worker81783",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leader__D2D14637CD94AC72", x => x.id_user);
                    table.ForeignKey(
                        name: "FKLeader405786",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turist",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_disabled = table.Column<bool>(nullable: false),
                    all_points = table.Column<int>(nullable: false),
                    confirmed_points = table.Column<int>(nullable: false),
                    id_badge_level = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_location = table.Column<int>(nullable: false),
                    end_location = table.Column<int>(nullable: false),
                    length = table.Column<float>(nullable: false),
                    elevation_gain = table.Column<float>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    mountain_range = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.id);
                    table.ForeignKey(
                        name: "FKSection74604",
                        column: x => x.end_location,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKSection521241",
                        column: x => x.mountain_range,
                        principalTable: "Mountain_range",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKSection198858",
                        column: x => x.start_location,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false),
                    id_mountain_range = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permissi__730A8F62FB70595C", x => new { x.id_user, x.id_mountain_range });
                    table.ForeignKey(
                        name: "FKPermission185604",
                        column: x => x.id_mountain_range,
                        principalTable: "Mountain_range",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPermission277937",
                        column: x => x.id_user,
                        principalTable: "Leader",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    id_turist = table.Column<int>(nullable: false),
                    id_badge_level = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__History__2A509D270486FE06", x => new { x.id_turist, x.id_badge_level });
                    table.ForeignKey(
                        name: "FKHistory256828",
                        column: x => x.id_badge_level,
                        principalTable: "Badge_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKHistory784901",
                        column: x => x.id_turist,
                        principalTable: "Turist",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<int>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    length = table.Column<float>(nullable: false),
                    elevation_gain = table.Column<float>(nullable: false),
                    id_turist = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.id);
                    table.ForeignKey(
                        name: "FKTrip848043",
                        column: x => x.id_turist,
                        principalTable: "Turist",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPS_proof",
                columns: table => new
                {
                    id_trip = table.Column<int>(nullable: false),
                    GPS_data = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GPS_proo__F5F227788A19A250", x => x.id_trip);
                    table.ForeignKey(
                        name: "FKGPS_proof590864",
                        column: x => x.id_trip,
                        principalTable: "Trip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo_proof",
                columns: table => new
                {
                    id_trip = table.Column<int>(nullable: false),
                    photo = table.Column<byte[]>(type: "image", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    id_trip = table.Column<int>(nullable: false),
                    id_section = table.Column<int>(nullable: false),
                    position_in_trip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Route__1A08A8B705DA99C5", x => new { x.id_trip, x.id_section, x.position_in_trip });
                    table.ForeignKey(
                        name: "FKRoute598500",
                        column: x => x.id_section,
                        principalTable: "Section",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKRoute778662",
                        column: x => x.id_trip,
                        principalTable: "Trip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Badge_level_id",
                table: "Badge_level",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "UQ__Badge_le__72E12F1BB5625E74",
                table: "Badge_level",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_id_badge_level",
                table: "History",
                column: "id_badge_level");

            migrationBuilder.CreateIndex(
                name: "Location_id",
                table: "Location",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "UQ__Location__72E12F1BFB130DF5",
                table: "Location",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Mountain_range_id",
                table: "Mountain_range",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Mountain_range_MountainSystemId",
                table: "Mountain_range",
                column: "MountainSystemId");

            migrationBuilder.CreateIndex(
                name: "UQ__Mountain__72E12F1B98630B12",
                table: "Mountain_range",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Mountain_system_id",
                table: "Mountain_system",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_id_mountain_range",
                table: "Permission",
                column: "id_mountain_range");

            migrationBuilder.CreateIndex(
                name: "IX_Route_id_section",
                table: "Route",
                column: "id_section");

            migrationBuilder.CreateIndex(
                name: "IX_Section_end_location",
                table: "Section",
                column: "end_location");

            migrationBuilder.CreateIndex(
                name: "Section_id",
                table: "Section",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Section_mountain_range",
                table: "Section",
                column: "mountain_range");

            migrationBuilder.CreateIndex(
                name: "IX_Section_start_location",
                table: "Section",
                column: "start_location");

            migrationBuilder.CreateIndex(
                name: "Trip_id",
                table: "Trip",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_id_turist",
                table: "Trip",
                column: "id_turist");

            migrationBuilder.CreateIndex(
                name: "IX_Turist_id_badge_level",
                table: "Turist",
                column: "id_badge_level");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E6164A513AC01",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "User_id",
                table: "Users",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commission_worker");

            migrationBuilder.DropTable(
                name: "Department_worker");

            migrationBuilder.DropTable(
                name: "GPS_proof");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Photo_proof");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Mountain_range");

            migrationBuilder.DropTable(
                name: "Turist");

            migrationBuilder.DropTable(
                name: "Mountain_system");

            migrationBuilder.DropTable(
                name: "Badge_level");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
