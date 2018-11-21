using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class PropriedadeMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Configuracao",
                table: "Mesas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Mesas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Historico",
                table: "Mesas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Inicio",
                table: "Mesas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoLance",
                table: "Mesas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Configuracao",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "Historico",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "Inicio",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "UltimoLance",
                table: "Mesas");
        }
    }
}
