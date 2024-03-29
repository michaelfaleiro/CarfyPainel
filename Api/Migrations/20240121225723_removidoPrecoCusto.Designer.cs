﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(DbApiContext))]
    [Migration("20240121225723_removidoPrecoCusto")]
    partial class removidoPrecoCusto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.Orcamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Chassi")
                        .HasMaxLength(17)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Chassi");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Cliente");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Placa")
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Placa");

                    b.Property<string>("Veiculo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Veiculo");

                    b.HasKey("Id");

                    b.ToTable("Orcamento", (string)null);
                });

            modelBuilder.Entity("Api.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT")
                        .HasColumnName("Link");

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Marca");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NomeProduto");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT")
                        .HasColumnName("Observacao");

                    b.Property<Guid?>("OrcamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("MONEY")
                        .HasColumnName("PrecoVenda");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Sku")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Sku");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Api.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_User_Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Api.Models.Produto", b =>
                {
                    b.HasOne("Api.Models.Orcamento", "Orcamento")
                        .WithMany("Produtos")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Produto_Orcamento");

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Api.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("Api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");
                });

            modelBuilder.Entity("Api.Models.Orcamento", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
