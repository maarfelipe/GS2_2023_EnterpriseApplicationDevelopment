﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DermaHelp.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    complemento = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    cidade = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    estado = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    id_consultorio = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpf_usuario = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    email_usuario = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    senha_usuario = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_consultorio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj_consultorio = table.Column<string>(type: "text", nullable: false),
                    id_endereco = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultorios_Enderecos_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultorios_id_endereco",
                table: "Consultorios",
                column: "id_endereco",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
