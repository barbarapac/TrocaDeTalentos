using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UTFPR");

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "UTFPR",
                columns: table => new
                {
                    cdpessoa = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    curso = table.Column<string>(nullable: false),
                    campus = table.Column<string>(nullable: false),
                    cidade = table.Column<string>(nullable: false),
                    estado = table.Column<string>(nullable: false),
                    dtcadastro = table.Column<DateTime>(nullable: false),
                    cdusuario = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoa", x => x.cdpessoa);
                });

            migrationBuilder.CreateTable(
                name: "usuarioarea",
                schema: "UTFPR",
                columns: table => new
                {
                    cdusuarioarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdarea = table.Column<long>(nullable: false),
                    cdusuario = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarioarea", x => x.cdusuarioarea);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "UTFPR",
                columns: table => new
                {
                    cdusuario = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ra = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    fotoperfil = table.Column<byte[]>(nullable: true),
                    _usuarioid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.cdusuario);
                    table.ForeignKey(
                        name: "fk_usuario_pessoa__usuarioid",
                        column: x => x._usuarioid,
                        principalSchema: "UTFPR",
                        principalTable: "pessoa",
                        principalColumn: "cdpessoa",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_usuario_usuarioarea__usuarioid",
                        column: x => x._usuarioid,
                        principalSchema: "UTFPR",
                        principalTable: "usuarioarea",
                        principalColumn: "cdusuarioarea",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "area",
                schema: "UTFPR",
                columns: table => new
                {
                    cdarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(nullable: false),
                    usuarioid = table.Column<long>(nullable: true),
                    _areaid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_area", x => x.cdarea);
                    table.ForeignKey(
                        name: "fk_area_usuario_usuarioid",
                        column: x => x.usuarioid,
                        principalSchema: "UTFPR",
                        principalTable: "usuario",
                        principalColumn: "cdusuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_area_usuarioarea__areaid",
                        column: x => x._areaid,
                        principalSchema: "UTFPR",
                        principalTable: "usuarioarea",
                        principalColumn: "cdusuarioarea",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "ix_area_usuarioid",
                schema: "UTFPR",
                table: "area",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "ix_area__areaid",
                schema: "UTFPR",
                table: "area",
                column: "_areaid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_usuario__usuarioid",
                schema: "UTFPR",
                table: "usuario",
                column: "_usuarioid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "area",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "UTFPR");

            migrationBuilder.DropTable(
                name: "usuarioarea",
                schema: "UTFPR");
        }
    }
}
