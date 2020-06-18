using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Base.EntityFrameworkCore
{
    public class HttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<HttpApiHostMigrationsDbContext>
    {
        public HttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Base"));

            return new HttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
