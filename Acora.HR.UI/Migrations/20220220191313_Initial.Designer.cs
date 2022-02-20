﻿// <auto-generated />
using System;
using Acora.HR.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Acora.HR.UI.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20220220191313_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Acora.HR.UI.Data.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"),
                            Name = "HR"
                        },
                        new
                        {
                            Id = new Guid("bbd65116-a83e-49ae-a074-e57cf341c568"),
                            Name = "IT"
                        },
                        new
                        {
                            Id = new Guid("0c6de67f-b6d5-4e61-ad6f-0c49583599bd"),
                            Name = "QA"
                        });
                });

            modelBuilder.Entity("Acora.HR.UI.Data.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeNumber"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeNumber = 1,
                            Address = "1 Top Street",
                            City = "Manchester",
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"),
                            Firstname = "TestA",
                            Lastname = "TestALastname"
                        },
                        new
                        {
                            EmployeeNumber = 2,
                            Address = "1 Left Street",
                            City = "Liverpool",
                            DateOfBirth = new DateTime(1989, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"),
                            Firstname = "TestB",
                            Lastname = "TestBLastname"
                        },
                        new
                        {
                            EmployeeNumber = 3,
                            Address = "1 Top Street",
                            City = "London",
                            DateOfBirth = new DateTime(1972, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = new Guid("4fbd45c2-f068-45e8-8656-d9560e8acd7d"),
                            Firstname = "TestC",
                            Lastname = "TestCLastname"
                        });
                });

            modelBuilder.Entity("Acora.HR.UI.Data.Models.Employee", b =>
                {
                    b.HasOne("Acora.HR.UI.Data.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Acora.HR.UI.Data.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
