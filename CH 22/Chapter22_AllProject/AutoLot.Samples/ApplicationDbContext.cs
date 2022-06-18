using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLot.Samples.Models;

namespace AutoLot.Samples
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            SavingChanges += (sender, args) =>
            {
                Console.WriteLine($"Saving changes for {((DbContext)sender).Database.GetConnectionString()}");
            };
            SavedChanges += (sender, args) =>
            {
                Console.WriteLine($"Saved {args.EntitiesSavedCount} entities");
            };
            SaveChangesFailed += (sender, args) =>
            {
                Console.WriteLine($"An exception occurred! {args.Exception.Message} entities");
            };
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API calls go here
            OnModelCreatingPartial(modelBuilder);

            //For TPT:
            //modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");
            //modelBuilder.Entity<Car>().ToTable("Cars");

            //Fluent API example:
            /*modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Inventory", "dbo");
                entity.HasKey(e => e.Id);
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
            
            // Default value example:
                entity.Property(e => e.Color)
                .HasColumnName("CarColor")
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Black");
            
            // Default value DateTime example:
            entity.Property(e => e.DateBuilt)
            .HasDefaultValueSql("getdate()");

            // One-to-Many example:
            entity.HasOne(d => d.MakeNavigation)
            .WithMany(p => p.Cars)
            .HasForeignKey(d => d.MakeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Inventory_Makes_MakeId");
            });
            
            // One-to-One example:
            modelBuilder.Entity<Radio>(entity =>
            {
            entity.HasIndex(e => e.CarId, "IX_Radios_CarId")
            .IsUnique();
            entity.HasOne(d => d.CarNavigation)
            .WithOne(p => p.RadioNavigation)
            .HasForeignKey<Radio>(d => d.CarId);
            });

            //Many-to-Many example:
            modelBuilder.Entity<Car>()
            .HasMany(p => p.Drivers)
            .WithMany(p => p.Cars)
            .UsingEntity<Dictionary<string, object>>(
            "CarDriver",
            j => j
            .HasOne<Driver>()
            .WithMany()
            .HasForeignKey("DriverId")
            .HasConstraintName("FK_CarDriver_Drivers_DriverId")
            .OnDelete(DeleteBehavior.Cascade),
            j => j
            .HasOne<Car>()
            .WithMany()
            .HasForeignKey("CarId")
            .HasConstraintName("FK_CarDriver_Cars_CarId")
            .OnDelete(DeleteBehavior.ClientCascade));
             */


        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        static void SampleSaveChanges()
        {
            //The factory is not meant to be used like this, but it’s demo code :-)
            var context = new ApplicationDbContextFactory().CreateDbContext(null);
            //make some changes
            context.SaveChanges();
        }

    }
}
