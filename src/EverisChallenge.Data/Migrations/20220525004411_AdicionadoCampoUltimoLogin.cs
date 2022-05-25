using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EverisChallenge.Data.Migrations
{
    public partial class AdicionadoCampoUltimoLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoLogin",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimoLogin",
                table: "Usuarios");
        }
    }
}
