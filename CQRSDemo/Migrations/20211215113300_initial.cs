using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSDemo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsOpened = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlaces",
                columns: table => new
                {
                    ParkingName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaces", x => new { x.ParkingName, x.Number });
                    table.ForeignKey(
                        name: "FK_ParkingPlaces_Parkings_ParkingName",
                        column: x => x.ParkingName,
                        principalTable: "Parkings",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "ParkingPlaces");

            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
