using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitCard.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaNome = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpresaRazao = table.Column<string>(maxLength: 100, nullable: false),
                    EmpresaNomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaCNPJ = table.Column<string>(maxLength: 40, nullable: false),
                    EmpresaEmail = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaEndereco = table.Column<string>(maxLength: 150, nullable: true),
                    EmpresaCidade = table.Column<string>(maxLength: 50, nullable: true),
                    EmpresaEstado = table.Column<string>(maxLength: 40, nullable: true),
                    EmpresaTelefone = table.Column<string>(maxLength: 15, nullable: true),
                    EmpresaDataCadastro = table.Column<DateTime>(nullable: false),
                    EmpresaStatus = table.Column<string>(maxLength: 3, nullable: true),
                    EmpresaAgencia = table.Column<string>(maxLength: 5, nullable: true),
                    EmpresaConta = table.Column<string>(maxLength: 10, nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CategoriaId",
                table: "Empresas",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
