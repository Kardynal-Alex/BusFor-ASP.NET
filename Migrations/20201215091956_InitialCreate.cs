using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusFor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time1 = table.Column<TimeSpan>(type: "time", nullable: false),
                    Time2 = table.Column<TimeSpan>(type: "time", nullable: false),
                    Location1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusPassengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    DateRace = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusPassengers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusInfos");

            migrationBuilder.DropTable(
                name: "BusPassengers");
        }
    }
}
