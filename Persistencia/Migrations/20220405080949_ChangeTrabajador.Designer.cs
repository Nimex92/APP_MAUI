﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(PresenciaContext))]
    [Migration("20220405080949_ChangeTrabajador")]
    partial class ChangeTrabajador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bibliotec.Grupo_Trabajo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HoraEntrada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HoraSalida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdGrupo");

                    b.ToTable("Grupo_Trabajo");
                });

            modelBuilder.Entity("Bibliotec.Trabajador", b =>
                {
                    b.Property<int>("numero_tarjeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("grupoIdGrupo")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("usuarioIdUser")
                        .HasColumnType("int");

                    b.HasKey("numero_tarjeta");

                    b.HasIndex("grupoIdGrupo");

                    b.HasIndex("usuarioIdUser");

                    b.ToTable("Trabajador");
                });

            modelBuilder.Entity("Bibliotec.Usuarios", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdUser");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ClassLibrary1.Fichajes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Entrada_Salida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaFichaje")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Grupo_TrabajoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("Trabajadornumero_tarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Grupo_TrabajoIdGrupo");

                    b.HasIndex("Trabajadornumero_tarjeta");

                    b.ToTable("TablaFichajes");
                });

            modelBuilder.Entity("Bibliotec.Trabajador", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", "grupo")
                        .WithMany()
                        .HasForeignKey("grupoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Usuarios", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupo");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ClassLibrary1.Fichajes", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", "Grupo_Trabajo")
                        .WithMany()
                        .HasForeignKey("Grupo_TrabajoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("Trabajadornumero_tarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo_Trabajo");

                    b.Navigation("Trabajador");
                });
#pragma warning restore 612, 618
        }
    }
}
