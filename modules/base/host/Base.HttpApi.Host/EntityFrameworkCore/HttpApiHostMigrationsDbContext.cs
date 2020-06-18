using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Base.EntityFrameworkCore
{
    public class HttpApiHostMigrationsDbContext : AbpDbContext<HttpApiHostMigrationsDbContext>
    {
        public HttpApiHostMigrationsDbContext(DbContextOptions<HttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBase();
        }
    }
}
