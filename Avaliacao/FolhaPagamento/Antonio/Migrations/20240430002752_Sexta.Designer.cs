﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Antonio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430002752_Sexta")]
    partial class Sexta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FolhaPagamento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Ano")
                        .HasColumnType("REAL");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ImpostoFgts")
                        .HasColumnType("REAL");

                    b.Property<double?>("ImpostoInss")
                        .HasColumnType("REAL");

                    b.Property<double?>("ImpostoIrrf")
                        .HasColumnType("REAL");

                    b.Property<double?>("Mes")
                        .HasColumnType("REAL");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("REAL");

                    b.Property<double?>("SalarioBruto")
                        .HasColumnType("REAL");

                    b.Property<double?>("SalarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double?>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FolhaPagamentos");
                });

            modelBuilder.Entity("Funcionario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("FolhaPagamento", b =>
                {
                    b.HasOne("Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
