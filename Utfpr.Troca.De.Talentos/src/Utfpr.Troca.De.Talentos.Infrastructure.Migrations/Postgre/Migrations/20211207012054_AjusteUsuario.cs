using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    public partial class AjusteUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "fotoperfil",
                schema: "UTFPR",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                schema: "UTFPR",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtcadastro",
                schema: "UTFPR",
                table: "pessoa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nome",
                schema: "UTFPR",
                table: "pessoa",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fotoperfil",
                schema: "UTFPR",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "tipo",
                schema: "UTFPR",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "dtcadastro",
                schema: "UTFPR",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "nome",
                schema: "UTFPR",
                table: "pessoa");
        }
    }
}
