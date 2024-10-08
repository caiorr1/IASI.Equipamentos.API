﻿// <auto-generated />
using System;
using IASI.Equipamentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace IASI.Equipamentos.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240913234215_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Consumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_consumo");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime?>("DataConsumo")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_consumo");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_criacao");

                    b.Property<float?>("EmissaoGasConsumo")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("emissao_gas_consumo");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    b.Property<float?>("QuantidadeConsumo")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("quantidade_consumo");

                    b.Property<string>("TipoEnergiaConsumo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_energia_consumo");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipamento");

                    b.ToTable("tb_iasi_equipamentos_consumo", (string)null);
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime?>("DataInstalacaoEquipamento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_instalacao_equipamento");

                    b.Property<string>("EstadoEquipamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("estado_equipamento");

                    b.Property<string>("LocalizacaoEquipamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("localizacao_equipamento");

                    b.Property<string>("NomeEquipamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_equipamento");

                    b.Property<string>("TipoEquipamento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_equipamento");

                    b.HasKey("Id");

                    b.ToTable("tb_iasi_equipamentos_equipamento", (string)null);
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Manutencao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_manutencao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime?>("DataManutencao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_manutencao");

                    b.Property<string>("DescricaoManutencao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("descricao_manutencao");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    b.Property<string>("TipoManutencao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_manutencao");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipamento");

                    b.ToTable("tb_iasi_equipamentos_manutencao", (string)null);
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Previsao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_previsao");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime?>("DataPrevisao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_previsao");

                    b.Property<string>("DescricaoPrevisao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("descricao_previsao");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    b.Property<float?>("ProbabilidadePrevisao")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("probabilidade_previsao");

                    b.Property<string>("TipoPrevisao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_previsao");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipamento");

                    b.ToTable("tb_iasi_equipamentos_previsao", (string)null);
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Residuo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_residuo");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime?>("DataGeracaoResiduo")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_geracao_residuo");

                    b.Property<string>("DestinoFinalResiduo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("destino_final_residuo");

                    b.Property<int>("IdEquipamento")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_equipamento");

                    b.Property<float?>("QuantidadeResiduo")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("quantidade_residuo");

                    b.Property<string>("TipoResiduo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_residuo");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipamento");

                    b.ToTable("tb_iasi_equipamentos_residuo", (string)null);
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Consumo", b =>
                {
                    b.HasOne("IASI.Equipamentos.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Consumos")
                        .HasForeignKey("IdEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Manutencao", b =>
                {
                    b.HasOne("IASI.Equipamentos.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Manutencoes")
                        .HasForeignKey("IdEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Previsao", b =>
                {
                    b.HasOne("IASI.Equipamentos.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Previsoes")
                        .HasForeignKey("IdEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Residuo", b =>
                {
                    b.HasOne("IASI.Equipamentos.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Residuos")
                        .HasForeignKey("IdEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("IASI.Equipamentos.Domain.Entities.Equipamento", b =>
                {
                    b.Navigation("Consumos");

                    b.Navigation("Manutencoes");

                    b.Navigation("Previsoes");

                    b.Navigation("Residuos");
                });
#pragma warning restore 612, 618
        }
    }
}
