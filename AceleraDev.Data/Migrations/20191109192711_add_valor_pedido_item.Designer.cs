﻿// <auto-generated />
using System;
using AceleraDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AceleraDev.Data.Migrations
{
    [DbContext(typeof(AceleraDevContext))]
    [Migration("20191109192711_add_valor_pedido_item")]
    partial class add_valor_pedido_item
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AceleraDev.Domain.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("cliente");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5819144-e118-4e03-8424-495a1283ecea"),
                            Ativo = true,
                            AtualizadoEm = new DateTime(2019, 11, 9, 16, 27, 11, 363, DateTimeKind.Local).AddTicks(7797),
                            CriadoEm = new DateTime(2019, 11, 9, 16, 27, 11, 363, DateTimeKind.Local).AddTicks(7797),
                            Nome = "Thiago"
                        });
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.PedidoItem", b =>
                {
                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("pedido_item");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("Id");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.Endereco", b =>
                {
                    b.HasOne("AceleraDev.Domain.Models.Cliente", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.Pedido", b =>
                {
                    b.HasOne("AceleraDev.Domain.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("AceleraDev.Domain.Models.PedidoItem", b =>
                {
                    b.HasOne("AceleraDev.Domain.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AceleraDev.Domain.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
