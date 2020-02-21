﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitCard.Data.Migrations
{
    public partial class criacao_base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CategoriaNome = table.Column<string>(maxLength: 40, nullable: false),
                    CategoriaFotoUrl = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    EmpresaRazao = table.Column<string>(maxLength: 100, nullable: false),
                    EmpresaNomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaCnpj = table.Column<string>(maxLength: 40, nullable: false),
                    EmpresaEmail = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaEndereco = table.Column<string>(maxLength: 150, nullable: true),
                    EmpresaCidade = table.Column<string>(maxLength: 50, nullable: true),
                    EmpresaEstado = table.Column<string>(maxLength: 40, nullable: true),
                    EmpresaTelefone = table.Column<string>(maxLength: 20, nullable: true),
                    EmpresaDataCadastro = table.Column<DateTime>(nullable: true),
                    EmpresaStatus = table.Column<string>(maxLength: 10, nullable: true),
                    EmpresaAgencia = table.Column<string>(maxLength: 5, nullable: true),
                    EmpresaConta = table.Column<string>(maxLength: 10, nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_CategoriaId",
                table: "Empresa",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
