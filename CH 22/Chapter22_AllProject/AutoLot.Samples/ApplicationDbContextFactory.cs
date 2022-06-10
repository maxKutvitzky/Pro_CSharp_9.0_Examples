using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLot.Samples
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = 
                @"Data Source=DESKTOP-H7TV7FI; Initial Catalog=AutoLot; TrustServerCertificate=True;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    } 
}
