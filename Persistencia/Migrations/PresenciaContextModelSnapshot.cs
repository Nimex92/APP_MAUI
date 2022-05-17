﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(PresenciaContext))]
    partial class PresenciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bibliotec.Calendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TrabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrabajadorNumeroTarjeta");

                    b.ToTable("Calendario");
                });

            modelBuilder.Entity("Bibliotec.Dia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CalendarioPerteneceId")
                        .HasColumnType("int");

                    b.Property<bool>("Disfrutado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CalendarioPerteneceId");

                    b.ToTable("DiaLibre");
                });

            modelBuilder.Entity("Bibliotec.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CIF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoCuentaMonetaria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Bibliotec.EquipoTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EquipoTrabajo");
                });

            modelBuilder.Entity("Bibliotec.Incidencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIncidencia")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Justificada")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MotivoIncidencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TrabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrabajadorNumeroTarjeta");

                    b.ToTable("Incidencias");
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

            modelBuilder.Entity("Bibliotec.Nomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("HorasEspeciales")
                        .HasColumnType("int");

                    b.Property<int>("HorasNormales")
                        .HasColumnType("int");

                    b.Property<int>("TotalAPercibir")
                        .HasColumnType("int");

                    b.Property<int>("TrabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("TrabajadorNumeroTarjeta");

                    b.ToTable("NominasTrabajadores");
                });

            modelBuilder.Entity("Bibliotec.SolicitudVacaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("SeAcepta")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Trabajador")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SolicitudesVacaciones");
                });

            modelBuilder.Entity("Bibliotec.TareaComenzada", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("InicioTarea")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("tareaIdTarea")
                        .HasColumnType("int");

                    b.Property<int>("trabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tareaIdTarea");

                    b.HasIndex("trabajadorNumeroTarjeta");

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

                    b.Property<DateTime>("inicioTarea")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("tareaIdTarea")
                        .HasColumnType("int");

                    b.Property<int>("trabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tareaIdTarea");

                    b.HasIndex("trabajadorNumeroTarjeta");

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
                    b.Property<int>("NumeroTarjeta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaDeContratacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroSeguridadSocial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PerteneceATurnos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioIdUser")
                        .HasColumnType("int");

                    b.HasKey("NumeroTarjeta");

                    b.HasIndex("UsuarioIdUser");

                    b.ToTable("Trabajador");
                });

            modelBuilder.Entity("Bibliotec.TrabajadorEnTurno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("fichajeId")
                        .HasColumnType("int");

                    b.Property<int>("trabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fichajeId");

                    b.HasIndex("trabajadorNumeroTarjeta");

                    b.ToTable("TrabajadorEnTurno");
                });

            modelBuilder.Entity("Bibliotec.Turno", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsDomingo")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsJueves")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsLunes")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsMartes")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsMiercoles")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsSabado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EsViernes")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("HoraSalida")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ValidoDesde")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ValidoHasta")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Nombre");

                    b.ToTable("Turno");
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

                    b.Property<int>("TrabajadorNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrabajadorNumeroTarjeta");

                    b.ToTable("Fichajes");
                });

            modelBuilder.Entity("EquipoTrabajoTareas", b =>
                {
                    b.Property<int>("EquipoTrabajoId")
                        .HasColumnType("int");

                    b.Property<int>("TareasIdTarea")
                        .HasColumnType("int");

                    b.HasKey("EquipoTrabajoId", "TareasIdTarea");

                    b.HasIndex("TareasIdTarea");

                    b.ToTable("EquipoTrabajoTareas");
                });

            modelBuilder.Entity("EquipoTrabajoTrabajador", b =>
                {
                    b.Property<int>("EquipoId")
                        .HasColumnType("int");

                    b.Property<int>("TrabajadoresNumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("EquipoId", "TrabajadoresNumeroTarjeta");

                    b.HasIndex("TrabajadoresNumeroTarjeta");

                    b.ToTable("EquipoTrabajoTrabajador");
                });

            modelBuilder.Entity("EquipoTrabajoTurno", b =>
                {
                    b.Property<int>("EquiposDeTrabajoId")
                        .HasColumnType("int");

                    b.Property<string>("TurnosNombre")
                        .HasColumnType("varchar(255)");

                    b.HasKey("EquiposDeTrabajoId", "TurnosNombre");

                    b.HasIndex("TurnosNombre");

                    b.ToTable("EquipoTrabajoTurno");
                });

            modelBuilder.Entity("EquipoTrabajoZonas", b =>
                {
                    b.Property<int>("EquiposTrabajoId")
                        .HasColumnType("int");

                    b.Property<int>("ZonasIdZona")
                        .HasColumnType("int");

                    b.HasKey("EquiposTrabajoId", "ZonasIdZona");

                    b.HasIndex("ZonasIdZona");

                    b.ToTable("EquipoTrabajoZonas");
                });

            modelBuilder.Entity("Bibliotec.Calendario", b =>
                {
                    b.HasOne("Bibliotec.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("Bibliotec.Dia", b =>
                {
                    b.HasOne("Bibliotec.Calendario", "CalendarioPertenece")
                        .WithMany("DiasDelCalendario")
                        .HasForeignKey("CalendarioPerteneceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalendarioPertenece");
                });

            modelBuilder.Entity("Bibliotec.Incidencia", b =>
                {
                    b.HasOne("Bibliotec.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("Bibliotec.Nomina", b =>
                {
                    b.HasOne("Bibliotec.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("Bibliotec.TareaComenzada", b =>
                {
                    b.HasOne("Bibliotec.Tareas", "tarea")
                        .WithMany()
                        .HasForeignKey("tareaIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "trabajador")
                        .WithMany()
                        .HasForeignKey("trabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tarea");

                    b.Navigation("trabajador");
                });

            modelBuilder.Entity("Bibliotec.TareaFinalizada", b =>
                {
                    b.HasOne("Bibliotec.Tareas", "tarea")
                        .WithMany()
                        .HasForeignKey("tareaIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "trabajador")
                        .WithMany()
                        .HasForeignKey("trabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tarea");

                    b.Navigation("trabajador");
                });

            modelBuilder.Entity("Bibliotec.Trabajador", b =>
                {
                    b.HasOne("Bibliotec.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Bibliotec.TrabajadorEnTurno", b =>
                {
                    b.HasOne("ClassLibrary1.Fichajes", "fichaje")
                        .WithMany()
                        .HasForeignKey("fichajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", "trabajador")
                        .WithMany()
                        .HasForeignKey("trabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fichaje");

                    b.Navigation("trabajador");
                });

            modelBuilder.Entity("ClassLibrary1.Fichajes", b =>
                {
                    b.HasOne("Bibliotec.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("EquipoTrabajoTareas", b =>
                {
                    b.HasOne("Bibliotec.EquipoTrabajo", null)
                        .WithMany()
                        .HasForeignKey("EquipoTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Tareas", null)
                        .WithMany()
                        .HasForeignKey("TareasIdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipoTrabajoTrabajador", b =>
                {
                    b.HasOne("Bibliotec.EquipoTrabajo", null)
                        .WithMany()
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Trabajador", null)
                        .WithMany()
                        .HasForeignKey("TrabajadoresNumeroTarjeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipoTrabajoTurno", b =>
                {
                    b.HasOne("Bibliotec.EquipoTrabajo", null)
                        .WithMany()
                        .HasForeignKey("EquiposDeTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Turno", null)
                        .WithMany()
                        .HasForeignKey("TurnosNombre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipoTrabajoZonas", b =>
                {
                    b.HasOne("Bibliotec.EquipoTrabajo", null)
                        .WithMany()
                        .HasForeignKey("EquiposTrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibliotec.Zonas", null)
                        .WithMany()
                        .HasForeignKey("ZonasIdZona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bibliotec.Calendario", b =>
                {
                    b.Navigation("DiasDelCalendario");
                });
#pragma warning restore 612, 618
        }
    }
}
