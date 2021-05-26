﻿// <auto-generated />
using System;
using DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.EFCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210526112926_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.PostalCodeTaxCalculationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxCalculationType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PostalCodeTaxCalculationTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e73e3ff-93ef-406e-a2d1-e24512f690db"),
                            PostalCode = "7441",
                            TaxCalculationType = 0
                        },
                        new
                        {
                            Id = new Guid("b5504049-3075-4b14-91ce-bb7a1b5411d0"),
                            PostalCode = "A100",
                            TaxCalculationType = 1
                        },
                        new
                        {
                            Id = new Guid("3cf8adeb-7f6f-4b33-9f2c-cc8a98622cda"),
                            PostalCode = "7000",
                            TaxCalculationType = 2
                        },
                        new
                        {
                            Id = new Guid("4263b528-2a8f-4bea-96d2-ce2d50b229de"),
                            PostalCode = "1000",
                            TaxCalculationType = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.TaxCalculation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AnnualIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CalculatedTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxCalculations");
                });
#pragma warning restore 612, 618
        }
    }
}
