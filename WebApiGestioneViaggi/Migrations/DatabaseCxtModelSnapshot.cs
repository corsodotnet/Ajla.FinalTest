﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiGestioneViaggi.Persistence;

namespace WebApiGestioneViaggi.Migrations
{
    [DbContext(typeof(DatabaseCxt))]
    partial class DatabaseCxtModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiGestioneViaggi.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroAbitanti")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroPositivi")
                        .HasColumnType("bigint");

                    b.Property<string>("PosizioneGeografica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroAbitanti")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroPositivi")
                        .HasColumnType("bigint");

                    b.Property<string>("PosizioneGeografica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContinentId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroAbitanti")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroPositivi")
                        .HasColumnType("bigint");

                    b.Property<string>("PosizioneGeografica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.City", b =>
                {
                    b.HasOne("WebApiGestioneViaggi.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.Country", b =>
                {
                    b.HasOne("WebApiGestioneViaggi.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId");

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.Continent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("WebApiGestioneViaggi.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}