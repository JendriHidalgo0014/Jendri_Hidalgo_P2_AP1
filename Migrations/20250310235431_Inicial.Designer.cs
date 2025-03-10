﻿// <auto-generated />
using System;
using Jendri_Hidalgo_P2_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jendri_Hidalgo_P2_AP1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250310235431_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jendri_Hidalgo_P2_AP1.Models.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CiudadId"));

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CiudadId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Jendri_Hidalgo_P2_AP1.Models.CiudadesDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleId");

                    b.HasIndex("CiudadId");

                    b.ToTable("CiudadesDetalle");
                });

            modelBuilder.Entity("Jendri_Hidalgo_P2_AP1.Models.Encuesta", b =>
                {
                    b.Property<int>("EncuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EncuestaId"));

                    b.Property<string>("Asignatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("EncuestaId");

                    b.ToTable("Encuesta");
                });

            modelBuilder.Entity("Jendri_Hidalgo_P2_AP1.Models.CiudadesDetalle", b =>
                {
                    b.HasOne("Jendri_Hidalgo_P2_AP1.Models.Ciudades", null)
                        .WithMany("CiudadesDetalle")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Jendri_Hidalgo_P2_AP1.Models.Ciudades", b =>
                {
                    b.Navigation("CiudadesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
