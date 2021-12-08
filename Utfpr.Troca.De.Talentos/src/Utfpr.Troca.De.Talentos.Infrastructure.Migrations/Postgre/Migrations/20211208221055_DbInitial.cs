using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    public partial class DbInitial : Migration
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
                    _usuarioid = table.Column<long>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "area",
                schema: "UTFPR",
                columns: table => new
                {
                    cdarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(nullable: false),
                    usuarioid = table.Column<long>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "usuarioarea",
                schema: "UTFPR",
                columns: table => new
                {
                    cdusuarioarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdusuario = table.Column<long>(nullable: false),
                    cdarea = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarioarea", x => x.cdusuarioarea);
                    table.ForeignKey(
                        name: "fk_usuarioarea_area_cdarea",
                        column: x => x.cdarea,
                        principalSchema: "UTFPR",
                        principalTable: "area",
                        principalColumn: "cdarea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuarioarea_usuario_cdusuario",
                        column: x => x.cdusuario,
                        principalSchema: "UTFPR",
                        principalTable: "usuario",
                        principalColumn: "cdusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_area_usuarioid",
                schema: "UTFPR",
                table: "area",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "ix_usuario__usuarioid",
                schema: "UTFPR",
                table: "usuario",
                column: "_usuarioid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_usuarioarea_cdarea",
                schema: "UTFPR",
                table: "usuarioarea",
                column: "cdarea");

            migrationBuilder.CreateIndex(
                name: "ix_usuarioarea_cdusuario",
                schema: "UTFPR",
                table: "usuarioarea",
                column: "cdusuario");
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
