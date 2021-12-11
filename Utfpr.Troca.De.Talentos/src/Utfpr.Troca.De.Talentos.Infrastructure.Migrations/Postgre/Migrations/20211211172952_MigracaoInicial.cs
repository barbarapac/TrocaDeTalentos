using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UTFPR");

            migrationBuilder.CreateTable(
                name: "area",
                schema: "UTFPR",
                columns: table => new
                {
                    idarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_area", x => x.idarea);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "UTFPR",
                columns: table => new
                {
                    idpessoa = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    idusuario = table.Column<long>(nullable: false),
                    curso = table.Column<string>(nullable: false),
                    campus = table.Column<string>(nullable: false),
                    cidade = table.Column<string>(nullable: false),
                    estado = table.Column<string>(nullable: false),
                    dtcadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoa", x => x.idpessoa);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "UTFPR",
                columns: table => new
                {
                    idusuario = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ra = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    fotoperfil = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.idusuario);
                    table.ForeignKey(
                        name: "fk_usuario_pessoa_idusuario",
                        column: x => x.idusuario,
                        principalSchema: "UTFPR",
                        principalTable: "pessoa",
                        principalColumn: "idpessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarioarea",
                schema: "UTFPR",
                columns: table => new
                {
                    idusuarioarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idusuario = table.Column<long>(nullable: false),
                    idarea = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarioarea", x => x.idusuarioarea);
                    table.ForeignKey(
                        name: "fk_usuarioarea_area_idarea",
                        column: x => x.idarea,
                        principalSchema: "UTFPR",
                        principalTable: "area",
                        principalColumn: "idarea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuarioarea_usuario_idusuario",
                        column: x => x.idusuario,
                        principalSchema: "UTFPR",
                        principalTable: "usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_usuarioarea_idarea",
                schema: "UTFPR",
                table: "usuarioarea",
                column: "idarea");

            migrationBuilder.CreateIndex(
                name: "ix_usuarioarea_idusuario",
                schema: "UTFPR",
                table: "usuarioarea",
                column: "idusuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarioarea",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "area",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "UTFPR");
        }
    }
}
