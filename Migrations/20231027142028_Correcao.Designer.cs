﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoEventos.Models;

#nullable disable

namespace ProjetoEventos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231027142028_Correcao")]
    partial class Correcao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoEventos.Models.Buffet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BuffetId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuffetTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BuffetTipo");

                    b.HasKey("Id");

                    b.ToTable("Buffet");
                });

            modelBuilder.Entity("ProjetoEventos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteCpf")
                        .HasColumnType("int")
                        .HasColumnName("ClienteCpf ");

                    b.Property<string>("ClienteEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ClienteEmail");

                    b.Property<string>("ClienteNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ClienteNome");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProjetoEventos.Models.Convidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConvidadoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConvidadoTotal")
                        .HasColumnType("int")
                        .HasColumnName("ConvidadoTotal");

                    b.HasKey("Id");

                    b.ToTable("Convidado");
                });

            modelBuilder.Entity("ProjetoEventos.Models.Decoracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DecoracaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DecoracaoTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DecoracaoTipo");

                    b.HasKey("Id");

                    b.ToTable("Decoracao");
                });

            modelBuilder.Entity("ProjetoEventos.Models.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LocalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocalNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LocalNome");

                    b.HasKey("Id");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("ProjetoEventos.Models.TipoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoEventoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EventoTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EventoTipo");

                    b.HasKey("Id");

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("ProjetoEventos.Models.TotalPagar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TotalPagarId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuffetId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("DecoracaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2")
                        .HasColumnName("Horario");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeConvidados")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeConvidados");

                    b.Property<int>("TipoEventoId")
                        .HasColumnType("int");

                    b.Property<double>("TotalValor")
                        .HasColumnType("float")
                        .HasColumnName("TotalValor");

                    b.HasKey("Id");

                    b.HasIndex("BuffetId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DecoracaoId");

                    b.HasIndex("LocalId");

                    b.HasIndex("TipoEventoId");

                    b.ToTable("TotalPagar");
                });

            modelBuilder.Entity("ProjetoEventos.Models.TotalPagar", b =>
                {
                    b.HasOne("ProjetoEventos.Models.Buffet", "Buffet")
                        .WithMany()
                        .HasForeignKey("BuffetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEventos.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEventos.Models.Decoracao", "Decoracao")
                        .WithMany()
                        .HasForeignKey("DecoracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEventos.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoEventos.Models.TipoEvento", "TipoEvento")
                        .WithMany()
                        .HasForeignKey("TipoEventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buffet");

                    b.Navigation("Cliente");

                    b.Navigation("Decoracao");

                    b.Navigation("Local");

                    b.Navigation("TipoEvento");
                });
#pragma warning restore 612, 618
        }
    }
}
