﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Veterinary_Clinic_Test.Context;

namespace Veterinary_Clinic_Test.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210702092516_alter_Diagnosis_add_ProductionTime")]
    partial class alter_Diagnosis_add_ProductionTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Breed")
                        .HasColumnType("text");

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("integer");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Animal", b =>
                {
                    b.HasOne("Veterinary_Clinic_Test.Models.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisId");

                    b.HasOne("Veterinary_Clinic_Test.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Veterinary_Clinic_Test.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Diagnosis");

                    b.Navigation("Doctor");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Veterinary_Clinic_Test.Models.Diagnosis", b =>
                {
                    b.HasOne("Veterinary_Clinic_Test.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
