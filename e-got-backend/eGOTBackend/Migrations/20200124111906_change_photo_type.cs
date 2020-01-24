using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGOTBackend.Migrations
{
    public partial class change_photo_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                table: "Photo_proof");

            migrationBuilder.DropColumn(
                name: "GPS_data",
                table: "GPS_proof");

            migrationBuilder.AddColumn<string>(
                name: "photo_url",
                table: "Photo_proof",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GPS_data_url",
                table: "GPS_proof",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo_url",
                table: "Photo_proof");

            migrationBuilder.DropColumn(
                name: "GPS_data_url",
                table: "GPS_proof");

            migrationBuilder.AddColumn<byte[]>(
                name: "photo",
                table: "Photo_proof",
                type: "image",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "GPS_data",
                table: "GPS_proof",
                type: "image",
                nullable: true);
        }
    }
}
