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
                    curso = table.Column<string>(nullable: false),
                    campus = table.Column<string>(nullable: false),
                    cidade = table.Column<string>(nullable: false),
                    estado = table.Column<string>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "atividade",
                schema: "UTFPR",
                columns: table => new
                {
                    cdusuarioarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdsecao = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atividade", x => x.cdusuarioarea);
                    table.ForeignKey(
                        name: "fk_atividade_usuario_cdusuarioarea",
                        column: x => x.cdusuarioarea,
                        principalSchema: "UTFPR",
                        principalTable: "usuario",
                        principalColumn: "cdusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "area",
                schema: "UTFPR",
                columns: table => new
                {
                    cdarea = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_area", x => x.cdarea);
                    table.ForeignKey(
                        name: "fk_area_atividade_cdarea",
                        column: x => x.cdarea,
                        principalSchema: "UTFPR",
                        principalTable: "atividade",
                        principalColumn: "cdusuarioarea",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "atividade",
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
