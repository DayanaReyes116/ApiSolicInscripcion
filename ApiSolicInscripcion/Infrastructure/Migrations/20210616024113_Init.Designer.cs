﻿// <auto-generated />
using ApiSolicInscripcion.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiSolicInscripcion.Migrations
{
    [DbContext(typeof(SolicitudDbContext))]
    [Migration("20210616024113_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("ApiSolicInscripcion.Core.Entities.Solicitudes", b =>
                {
                    b.Property<int>("iId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("iEdad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("iIdCasa")
                        .HasColumnType("INTEGER");

                    b.Property<int>("iIdentificacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("sApellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("sName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("sNameCasa")
                        .HasColumnType("TEXT");

                    b.HasKey("iId");

                    b.ToTable("Solicitud");
                });
#pragma warning restore 612, 618
        }
    }
}