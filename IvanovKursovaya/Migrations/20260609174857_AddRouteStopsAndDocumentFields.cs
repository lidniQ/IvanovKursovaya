using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanovKursovaya.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteStopsAndDocumentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Tickets",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Tickets",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PassengerBirthDate",
                table: "Tickets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerCitizenship",
                table: "Tickets",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerGender",
                table: "Tickets",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerIma",
                table: "Tickets",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerPatronymic",
                table: "Tickets",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerSurname",
                table: "Tickets",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tariff",
                table: "Tickets",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RouteStops",
                columns: table => new
                {
                    RouteStopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false),
                    StopNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StationName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TravelTime = table.Column<string>(type: "TEXT", nullable: true),
                    DistanceKm = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStops", x => x.RouteStopId);
                    table.ForeignKey(
                        name: "FK_RouteStops_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_RouteId",
                table: "RouteStops",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteStops");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerBirthDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerCitizenship",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerGender",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerIma",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerPatronymic",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PassengerSurname",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tariff",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "AspNetUsers");
        }
    }
}
