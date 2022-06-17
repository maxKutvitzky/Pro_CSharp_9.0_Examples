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
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API calls go here
            OnModelCreatingPartial(modelBuilder);
            //For TPT:
            //modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");
            //modelBuilder.Entity<Car>().ToTable("Cars");
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
