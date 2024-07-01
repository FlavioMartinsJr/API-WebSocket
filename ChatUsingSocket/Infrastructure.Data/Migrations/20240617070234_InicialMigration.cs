using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    img = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_chat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mensagemRecebida = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    mensagemEnviada = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    userRecebido = table.Column<int>(type: "int", nullable: true),
                    userEnviado = table.Column<int>(type: "int", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chat_UserEnviado",
                        column: x => x.userEnviado,
                        principalTable: "tb_usuario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chat_UserRecebido",
                        column: x => x.userRecebido,
                        principalTable: "tb_usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_chat_userEnviado",
                table: "tb_chat",
                column: "userEnviado");

            migrationBuilder.CreateIndex(
                name: "IX_tb_chat_userRecebido",
                table: "tb_chat",
                column: "userRecebido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_chat");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
