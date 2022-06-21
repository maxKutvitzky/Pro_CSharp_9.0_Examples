using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoLot.Models.Entities;

#nullable disable

namespace AutoLot.Dal.EfStructures
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarDriver> CarDrivers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CarDriver>(entity =>
            {
                entity.HasKey(e => new { e.CarsId, e.DriversId });

                entity.ToTable("CarDriver");

                entity.HasIndex(e => e.DriversId, "IX_CarDriver_DriversId");

                entity.HasOne(d => d.Cars)
                    .WithMany(p => p.CarDrivers)
                    .HasForeignKey(d => d.CarsId);

                entity.HasOne(d => d.Drivers)
                    .WithMany(p => p.CarDrivers)
                    .HasForeignKey(d => d.DriversId);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasIndex(e => e.MakeId, "IX_Inventory_MakeId");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.MakeId);
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_Radios_CarId");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Radios)
                    .HasForeignKey(d => d.CarId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
