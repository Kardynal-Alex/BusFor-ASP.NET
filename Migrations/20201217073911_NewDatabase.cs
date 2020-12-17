using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusFor.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BusPassengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TrainInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time1 = table.Column<TimeSpan>(type: "time", nullable: false),
                    Time2 = table.Column<TimeSpan>(type: "time", nullable: false),
                    Location1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    NumberOfCoupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPlatzKarte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoupePrice = table.Column<double>(type: "float", nullable: false),
                    PlatzKartePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainPassengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Van = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    DateRace = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPostel = table.Column<bool>(type: "bit", nullable: false),
                    TrainInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainPassengers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainInfos");

            migrationBuilder.DropTable(
                name: "TrainPassengers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BusPassengers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
