using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IASI.Equipamentos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_iasi_equipamentos_equipamento",
                columns: table => new
                {
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    tipo_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    localizacao_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_instalacao_equipamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    estado_equipamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_equipamentos_equipamento", x => x.id_equipamento);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_equipamentos_consumo",
                columns: table => new
                {
                    id_consumo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data_consumo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    quantidade_consumo = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    tipo_energia_consumo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    emissao_gas_consumo = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_equipamentos_consumo", x => x.id_consumo);
                    table.ForeignKey(
                        name: "FK_tb_iasi_equipamentos_consumo_tb_iasi_equipamentos_equipamento_id_equipamento",
                        column: x => x.id_equipamento,
                        principalTable: "tb_iasi_equipamentos_equipamento",
                        principalColumn: "id_equipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_equipamentos_manutencao",
                columns: table => new
                {
                    id_manutencao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tipo_manutencao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_manutencao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    descricao_manutencao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_equipamentos_manutencao", x => x.id_manutencao);
                    table.ForeignKey(
                        name: "FK_tb_iasi_equipamentos_manutencao_tb_iasi_equipamentos_equipamento_id_equipamento",
                        column: x => x.id_equipamento,
                        principalTable: "tb_iasi_equipamentos_equipamento",
                        principalColumn: "id_equipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_equipamentos_previsao",
                columns: table => new
                {
                    id_previsao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data_previsao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    tipo_previsao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    descricao_previsao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    probabilidade_previsao = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_equipamentos_previsao", x => x.id_previsao);
                    table.ForeignKey(
                        name: "FK_tb_iasi_equipamentos_previsao_tb_iasi_equipamentos_equipamento_id_equipamento",
                        column: x => x.id_equipamento,
                        principalTable: "tb_iasi_equipamentos_equipamento",
                        principalColumn: "id_equipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_equipamentos_residuo",
                columns: table => new
                {
                    id_residuo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    id_equipamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tipo_residuo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    quantidade_residuo = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    data_geracao_residuo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    destino_final_residuo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_equipamentos_residuo", x => x.id_residuo);
                    table.ForeignKey(
                        name: "FK_tb_iasi_equipamentos_residuo_tb_iasi_equipamentos_equipamento_id_equipamento",
                        column: x => x.id_equipamento,
                        principalTable: "tb_iasi_equipamentos_equipamento",
                        principalColumn: "id_equipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_equipamentos_consumo_id_equipamento",
                table: "tb_iasi_equipamentos_consumo",
                column: "id_equipamento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_equipamentos_manutencao_id_equipamento",
                table: "tb_iasi_equipamentos_manutencao",
                column: "id_equipamento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_equipamentos_previsao_id_equipamento",
                table: "tb_iasi_equipamentos_previsao",
                column: "id_equipamento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_equipamentos_residuo_id_equipamento",
                table: "tb_iasi_equipamentos_residuo",
                column: "id_equipamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_iasi_equipamentos_consumo");

            migrationBuilder.DropTable(
                name: "tb_iasi_equipamentos_manutencao");

            migrationBuilder.DropTable(
                name: "tb_iasi_equipamentos_previsao");

            migrationBuilder.DropTable(
                name: "tb_iasi_equipamentos_residuo");

            migrationBuilder.DropTable(
                name: "tb_iasi_equipamentos_equipamento");
        }
    }
}
