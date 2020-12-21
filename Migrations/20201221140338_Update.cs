using Microsoft.EntityFrameworkCore.Migrations;

namespace BusFor.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanePassengers_PassengerDocuments_PassengerDocumentId",
                table: "PlanePassengers");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerDocumentId",
                table: "PlanePassengers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanePassengers_PassengerDocuments_PassengerDocumentId",
                table: "PlanePassengers",
                column: "PassengerDocumentId",
                principalTable: "PassengerDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanePassengers_PassengerDocuments_PassengerDocumentId",
                table: "PlanePassengers");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerDocumentId",
                table: "PlanePassengers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanePassengers_PassengerDocuments_PassengerDocumentId",
                table: "PlanePassengers",
                column: "PassengerDocumentId",
                principalTable: "PassengerDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
