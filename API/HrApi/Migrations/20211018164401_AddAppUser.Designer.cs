﻿// <auto-generated />
using System;
using HrApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HrApi.Migrations
{
    [DbContext(typeof(HrContext))]
    [Migration("20211018164401_AddAppUser")]
    partial class AddAppUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HrApi.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Company_Employeeid")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Company_Employeeid");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HrApi.Models.Company_Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Company_id")
                        .HasColumnType("int");

                    b.Property<int>("Employee_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Company_Employee");
                });

            modelBuilder.Entity("HrApi.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Company_Employeeid")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Company_Employeeid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HrApi.Models.Company", b =>
                {
                    b.HasOne("HrApi.Models.Company_Employee", null)
                        .WithMany("Companies")
                        .HasForeignKey("Company_Employeeid");
                });

            modelBuilder.Entity("HrApi.Models.Employee", b =>
                {
                    b.HasOne("HrApi.Models.Company_Employee", null)
                        .WithMany("Employees")
                        .HasForeignKey("Company_Employeeid");
                });

            modelBuilder.Entity("HrApi.Models.Company_Employee", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
