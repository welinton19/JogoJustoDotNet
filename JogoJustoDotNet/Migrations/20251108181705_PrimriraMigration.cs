using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoJustoDotNet.Migrations
{
    /// <inheritdoc />
    public partial class PrimriraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDepartamento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GerenteId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaEsg",
                columns: table => new
                {
                    IdMetaEsg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMetaEsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoMetaEsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorReferenciaMetaEsg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAtualMetaEsg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AtualizacaoDados = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrazoMetaEsg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaEsg", x => x.IdMetaEsg);
                    table.ForeignKey(
                        name: "FK_MetaEsg_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId");
                });

            migrationBuilder.CreateTable(
                name: "EsgLogModel",
                columns: table => new
                {
                    IdEsgLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoIdDepartamento = table.Column<int>(type: "int", nullable: false),
                    AcaoRealizada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recomacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAcao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsgLogModel", x => x.IdEsgLog);
                    table.ForeignKey(
                        name: "FK_EsgLogModel_Departamento_DepartamentoIdDepartamento",
                        column: x => x.DepartamentoIdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StPcd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPcd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CargaHoraria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoCargaHoraria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MentorFuncionarioId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoIdDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Departamento_DepartamentoIdDepartamento",
                        column: x => x.DepartamentoIdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Funcionario_MentorFuncionarioId",
                        column: x => x.MentorFuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvimentoModel",
                columns: table => new
                {
                    IdDesenvolvimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeTreinamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treinamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoHoras = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Orgao = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DataRegistroDeDados = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusRegistro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvimentoModel", x => x.IdDesenvolvimento);
                    table.ForeignKey(
                        name: "FK_DesenvolvimentoModel_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_EmpresaId",
                table: "Departamento",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvimentoModel_FuncionarioId",
                table: "DesenvolvimentoModel",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EsgLogModel_DepartamentoIdDepartamento",
                table: "EsgLogModel",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoIdDepartamento",
                table: "Funcionario",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_MentorFuncionarioId",
                table: "Funcionario",
                column: "MentorFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaEsg_EmpresaId",
                table: "MetaEsg",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesenvolvimentoModel");

            migrationBuilder.DropTable(
                name: "EsgLogModel");

            migrationBuilder.DropTable(
                name: "MetaEsg");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
