using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DermaHelp.Migrations
{
    /// <inheritdoc />
    public partial class creating_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_consultorio = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    cnpj_consultorio = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    id_endereco = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_medico = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    crm_medico = table.Column<string>(type: "NVARCHAR2(13)", maxLength: 13, nullable: false),
                    email_medico = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_usuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    cpf_usuario = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    email_usuario = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    senha_usuario = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    logradouro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "NUMBER(10)", maxLength: 5, nullable: false),
                    complemento = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: true),
                    cidade = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    cep = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    id_consultorio = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Consultorios_id_consultorio",
                        column: x => x.id_consultorio,
                        principalTable: "Consultorios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicosConsultorios",
                columns: table => new
                {
                    id_medico = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    id_consultorio = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosConsultorios", x => new { x.id_medico, x.id_consultorio });
                    table.ForeignKey(
                        name: "FK_MedicosConsultorios_Consultorios_id_consultorio",
                        column: x => x.id_consultorio,
                        principalTable: "Consultorios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicosConsultorios_Medicos_id_medico",
                        column: x => x.id_medico,
                        principalTable: "Medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_consulta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_medico = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    id_consultorio = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultas_Consultorios_id_consultorio",
                        column: x => x.id_consultorio,
                        principalTable: "Consultorios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_id_medico",
                        column: x => x.id_medico,
                        principalTable: "Medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    image_data = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    resultado_imagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imagens_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_consultorio",
                table: "Consultas",
                column: "id_consultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_medico",
                table: "Consultas",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_usuario",
                table: "Consultas",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_id_consultorio",
                table: "Enderecos",
                column: "id_consultorio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_id_usuario",
                table: "Imagens",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_MedicosConsultorios_id_consultorio",
                table: "MedicosConsultorios",
                column: "id_consultorio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "MedicosConsultorios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
