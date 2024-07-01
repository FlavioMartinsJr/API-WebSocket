﻿// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617070234_InicialMigration")]
    partial class InicialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.EntitiesConfigs.TblChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<string>("MensagemEnviada")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("mensagemEnviada");

                    b.Property<string>("MensagemRecebida")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("mensagemRecebida");

                    b.Property<int?>("UsuarioEnviadoId")
                        .HasColumnType("int")
                        .HasColumnName("userEnviado");

                    b.Property<int?>("UsuarioRecebidoId")
                        .HasColumnType("int")
                        .HasColumnName("userRecebido");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioEnviadoId");

                    b.HasIndex("UsuarioRecebidoId");

                    b.ToTable("tb_chat", (string)null);
                });

            modelBuilder.Entity("Domain.EntitiesConfigs.TblUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<DateTime?>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("dataAlteracao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("dataCriacao")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Img")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("img");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("Domain.EntitiesConfigs.TblChat", b =>
                {
                    b.HasOne("Domain.EntitiesConfigs.TblUsuario", "UsuarioEnviado")
                        .WithMany("TblChatUsuarioEnviado")
                        .HasForeignKey("UsuarioEnviadoId")
                        .HasConstraintName("FK_Chat_UserEnviado");

                    b.HasOne("Domain.EntitiesConfigs.TblUsuario", "UsuarioRecebido")
                        .WithMany("TblChatUsuarioRecebido")
                        .HasForeignKey("UsuarioRecebidoId")
                        .HasConstraintName("FK_Chat_UserRecebido");

                    b.Navigation("UsuarioEnviado");

                    b.Navigation("UsuarioRecebido");
                });

            modelBuilder.Entity("Domain.EntitiesConfigs.TblUsuario", b =>
                {
                    b.Navigation("TblChatUsuarioEnviado");

                    b.Navigation("TblChatUsuarioRecebido");
                });
#pragma warning restore 612, 618
        }
    }
}