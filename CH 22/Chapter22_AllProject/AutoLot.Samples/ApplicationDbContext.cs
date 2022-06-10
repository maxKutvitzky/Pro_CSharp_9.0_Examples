using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API calls go here
            OnModelCreatingPartial(modelBuilder);
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
