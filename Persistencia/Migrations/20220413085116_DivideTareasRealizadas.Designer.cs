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
    [Migration("20220413085116_DivideTareasRealizadas")]
    partial class DivideTareasRealizadas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
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

            modelBuilder.Entity("Bibliotec.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescripcionEvento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoEvento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Bibliotec.TareaComenzada", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("InicioTarea")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("grupoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("tareaIdTarea")
                        .HasColumnType("int");

                    b.Property<int>("trabajadornumero_tarjeta")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("grupoIdGrupo");

                    b.HasIndex("tareaIdTarea");

                    b.HasIndex("trabajadornumero_tarjeta");

                    b.ToTable("TareasComenzadas");
                });

            modelBuilder.Entity("Bibliotec.TareaFinalizada", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("EnHora")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FinTarea")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("HorasUsadas")
                        .HasColumnType("double");

                    b.Property<int>("grupoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("tareaIdTarea")
                        .HasColumnType("int");

                    b.Property<int>("trabajadornumero_tarjeta")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("grupoIdGrupo");

                    b.HasIndex("tareaIdTarea");

                    b.HasIndex("trabajadornumero_tarjeta");

                    b.ToTable("TareasFinalizadas");
                });

            modelBuilder.Entity("Bibliotec.Tareas", b =>
                {
                    b.Property<int>("IdTarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NombreTarea")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TiempoEstimado")
                        .HasColumnType("double");

                    b.HasKey("IdTarea");

                    b.ToTable("Tareas");
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

            modelBuilder.Entity("Bibliotec.Zonas", b =>
                {
                    b.Property<int>("IdZona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdZona");

                    b.ToTable("Zonas");
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

            modelBuilder.Entity("Grupo_TrabajoTareas", b =>
                {
                    b.Property<int>("GruposTrabajoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("TareasIdTarea")
                        .HasColumnType("int");

                    b.HasKey("GruposTrabajoIdGrupo", "TareasIdTarea");

                    b.HasIndex("TareasIdTarea");

                    b.ToTable("Grupo_TrabajoTareas");
                });

            modelBuilder.Entity("Grupo_TrabajoZonas", b =>
                {
                    b.Property<int>("GruposTrabajoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("ZonasIdZona")
                        .HasColumnType("int");

                    b.HasKey("GruposTrabajoIdGrupo", "ZonasIdZona");

                    b.HasIndex("ZonasIdZona");

                    b.ToTable("Grupo_TrabajoZonas");
                });

            modelBuilder.Entity("Bibliotec.TareaComenzada", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", "grupo")
                        .WithMany()
                        .HasForeignKey("grupoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Tareas", "tarea")
                        .WithMany()
                        .HasForeignKey("tareaIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "trabajador")
                        .WithMany()
                        .HasForeignKey("trabajadornumero_tarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupo");

                    b.Navigation("tarea");

                    b.Navigation("trabajador");
                });

            modelBuilder.Entity("Bibliotec.TareaFinalizada", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", "grupo")
                        .WithMany()
                        .HasForeignKey("grupoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Tareas", "tarea")
                        .WithMany()
                        .HasForeignKey("tareaIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "trabajador")
                        .WithMany()
                        .HasForeignKey("trabajadornumero_tarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupo");

                    b.Navigation("tarea");

                    b.Navigation("trabajador");
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

            modelBuilder.Entity("Grupo_TrabajoTareas", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", null)
                        .WithMany()
                        .HasForeignKey("GruposTrabajoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Tareas", null)
                        .WithMany()
                        .HasForeignKey("TareasIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Grupo_TrabajoZonas", b =>
                {
                    b.HasOne("Bibliotec.Grupo_Trabajo", null)
                        .WithMany()
                        .HasForeignKey("GruposTrabajoIdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Zonas", null)
                        .WithMany()
                        .HasForeignKey("ZonasIdZona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
