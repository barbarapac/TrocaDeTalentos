using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AREA",
                columns: table => new
                {
                    IDAREA = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRICAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AREA", x => x.IDAREA);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    IDPESSOA = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(nullable: false),
                    IDUSUARIO = table.Column<long>(nullable: false),
                    CURSO = table.Column<string>(nullable: false),
                    CAMPUS = table.Column<string>(nullable: false),
                    CIDADE = table.Column<string>(nullable: false),
                    ESTADO = table.Column<string>(nullable: false),
                    DTCADASTRO = table.Column<DateTime>(nullable: false),
                    FOTOPERFIL = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.IDPESSOA);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RA = table.Column<string>(nullable: false),
                    EMAIL = table.Column<string>(nullable: false),
                    SENHA = table.Column<string>(nullable: false),
                    TIPO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IDUSUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIO_PESSOA_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "PESSOA",
                        principalColumn: "IDPESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOAREA",
                columns: table => new
                {
                    IDUSUARIOAREA = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDUSUARIO = table.Column<long>(nullable: false),
                    IDAREA = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOAREA", x => x.IDUSUARIOAREA);
                    table.ForeignKey(
                        name: "FK_USUARIOAREA_AREA_IDAREA",
                        column: x => x.IDAREA,
                        principalTable: "AREA",
                        principalColumn: "IDAREA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOAREA_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOAREA_IDAREA",
                table: "USUARIOAREA",
                column: "IDAREA");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOAREA_IDUSUARIO",
                table: "USUARIOAREA",
                column: "IDUSUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOAREA");

            migrationBuilder.DropTable(
                name: "AREA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}
