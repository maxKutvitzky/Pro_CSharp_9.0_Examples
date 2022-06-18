﻿// <auto-generated />
using System;
using AutoLot.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoLot.Samples.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220618125003_One2One")]
    partial class One2One
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Radio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("HasSubWoofers")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTweeters")
                        .HasColumnType("bit");

                    b.Property<string>("RadioId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Radios");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.HasOne("AutoLot.Samples.Models.Make", "MakeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MakeNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Radio", b =>
                {
                    b.HasOne("AutoLot.Samples.Models.Car", "CarNavigation")
                        .WithOne("RadioNavigation")
                        .HasForeignKey("AutoLot.Samples.Models.Radio", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Car", b =>
                {
                    b.Navigation("RadioNavigation");
                });

            modelBuilder.Entity("AutoLot.Samples.Models.Make", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
