﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre;

namespace Utfpr.Troca.De.Talentos.Infrastructure.Migrations.Postgre.Migrations
{
    [DbContext(typeof(PostgreSqlMigrationsDbContext))]
    [Migration("20211211210316_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.Areas.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDAREA")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_AREA");

                    b.ToTable("AREA");
                });

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.Pessoas.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDPESSOA")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasColumnName("CAMPUS")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("CIDADE")
                        .HasColumnType("text");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasColumnName("CURSO")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DTCADASTRO")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasColumnType("text");

                    b.Property<byte[]>("FotoPerfil")
                        .HasColumnName("FOTOPERFIL")
                        .HasColumnType("bytea");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("text");

                    b.Property<long>("UsuarioId")
                        .HasColumnName("IDUSUARIO")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_PESSOA");

                    b.ToTable("PESSOA");
                });

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.Usuario.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDUSUARIO")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("text");

                    b.Property<string>("Ra")
                        .IsRequired()
                        .HasColumnName("RA")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .HasColumnName("TIPO")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_USUARIO");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.UsuarioArea.UsuarioArea", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDUSUARIOAREA")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("_areaId")
                        .HasColumnName("IDAREA")
                        .HasColumnType("bigint");

                    b.Property<long>("_usuarioId")
                        .HasColumnName("IDUSUARIO")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_USUARIOAREA");

                    b.HasIndex("_areaId")
                        .HasName("IX_USUARIOAREA_IDAREA");

                    b.HasIndex("_usuarioId")
                        .HasName("IX_USUARIOAREA_IDUSUARIO");

                    b.ToTable("USUARIOAREA");
                });

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.Usuario.Usuario", b =>
                {
                    b.HasOne("Utfpr.Troca.De.Talentos.Domain.Pessoas.Pessoa", null)
                        .WithOne("Usuario")
                        .HasForeignKey("Utfpr.Troca.De.Talentos.Domain.Usuario.Usuario", "Id")
                        .HasConstraintName("FK_USUARIO_PESSOA_IDUSUARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Utfpr.Troca.De.Talentos.Domain.UsuarioArea.UsuarioArea", b =>
                {
                    b.HasOne("Utfpr.Troca.De.Talentos.Domain.Areas.Area", "Area")
                        .WithMany()
                        .HasForeignKey("_areaId")
                        .HasConstraintName("FK_USUARIOAREA_AREA_IDAREA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Utfpr.Troca.De.Talentos.Domain.Usuario.Usuario", "Usuario")
                        .WithMany("Areas")
                        .HasForeignKey("_usuarioId")
                        .HasConstraintName("FK_USUARIOAREA_USUARIO_IDUSUARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}