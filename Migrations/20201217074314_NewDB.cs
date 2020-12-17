using Microsoft.EntityFrameworkCore.Migrations;

namespace BusFor.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TrainInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TrainInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
