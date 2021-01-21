using Data.Entities.Entities;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities.DbContext
{
    public class EshopDBContextFactory : IDesignTimeDbContextFactory<EshopDBContext>
    {
        public EshopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();

            string connectionString = configuration.GetConnectionString("eShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<EshopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EshopDBContext(optionsBuilder.Options);
        }
    }
}
