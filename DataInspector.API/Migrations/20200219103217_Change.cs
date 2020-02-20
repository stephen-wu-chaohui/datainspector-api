using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataInspector.API.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Sites",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Sites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Sensors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Sensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Samples",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Samples",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Deleted", "Description", "LastUpdated", "Name" },
                values: new object[] { 1, false, "This example shows SignalR synchrounizes samples among mobiles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demo Project" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Samples");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Samples");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Projects");
        }
    }
}
