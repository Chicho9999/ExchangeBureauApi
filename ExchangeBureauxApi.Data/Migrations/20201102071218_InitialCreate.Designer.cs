﻿// <auto-generated />
using System;
using ExchangeBureauxApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExchangeBureauxApi.Data.Migrations
{
    [DbContext(typeof(CurrencyExchangeDbContext))]
    [Migration("20201102071218_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExchangeBureauxApi.Data.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7153),
                            Identifier = "USD",
                            Name = "DOLAR"
                        },
                        new
                        {
                            CurrencyId = 2,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7277),
                            Identifier = "BRL",
                            Name = "REAL"
                        },
                        new
                        {
                            CurrencyId = 3,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7280),
                            Identifier = "ARS",
                            Name = "PESO ARGENTINO"
                        });
                });

            modelBuilder.Entity("ExchangeBureauxApi.Data.Models.CurrencyExchange", b =>
                {
                    b.Property<int>("CurrencyExchangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ConversionValue")
                        .HasColumnType("float");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyFromId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyToId")
                        .HasColumnType("int");

                    b.Property<double>("InverseConversionValue")
                        .HasColumnType("float");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CurrencyExchangeId");

                    b.HasIndex("CurrencyFromId");

                    b.HasIndex("CurrencyToId");

                    b.ToTable("CurrencyExchanges");

                    b.HasData(
                        new
                        {
                            CurrencyExchangeId = 1,
                            ConversionValue = 83.859999999999999,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7848),
                            CurrencyFromId = 3,
                            CurrencyToId = 1,
                            InverseConversionValue = 77.469999999999999
                        },
                        new
                        {
                            CurrencyExchangeId = 2,
                            ConversionValue = 77.469999999999999,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7907),
                            CurrencyFromId = 1,
                            CurrencyToId = 3,
                            InverseConversionValue = 83.859999999999999
                        },
                        new
                        {
                            CurrencyExchangeId = 3,
                            ConversionValue = 14.039999999999999,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7941),
                            CurrencyFromId = 3,
                            CurrencyToId = 2,
                            InverseConversionValue = 12.529999999999999
                        },
                        new
                        {
                            CurrencyExchangeId = 4,
                            ConversionValue = 12.529999999999999,
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7942),
                            CurrencyFromId = 2,
                            CurrencyToId = 3,
                            InverseConversionValue = 14.039999999999999
                        });
                });

            modelBuilder.Entity("ExchangeBureauxApi.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Rivadavia",
                            CreatedBy = 1,
                            CreatedDate = new DateTime(2020, 11, 2, 4, 12, 18, 38, DateTimeKind.Local).AddTicks(5070),
                            Email = "lisandrochichi@gmail.com",
                            FirstName = "Lisandro",
                            LastName = "Chichi",
                            Password = "AQAAAAEAACcQAAAAEMeKl8RaiTOOjSJc1l7aQRGGHSs/w7HfS0gDEN6CWpGsDVVEQGpiO+0ldE3oGxTMYw==",
                            Username = "LisandroAdmin"
                        });
                });

            modelBuilder.Entity("ExchangeBureauxApi.Data.Models.CurrencyExchange", b =>
                {
                    b.HasOne("ExchangeBureauxApi.Data.Models.Currency", "CurrencyFrom")
                        .WithMany("FromCurrencyExchanges")
                        .HasForeignKey("CurrencyFromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExchangeBureauxApi.Data.Models.Currency", "CurrencyTo")
                        .WithMany("ToCurrencyExchanges")
                        .HasForeignKey("CurrencyToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}