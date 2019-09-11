using Base.Entity;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Base.EntityFrameworkCore
{
    [ConnectionStringName("Base")]
    public class BaseDbContext : AbpDbContext<BaseDbContext>, IBaseDbContext
    {
        public static string TablePrefix { get; set; } = BaseConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = BaseConsts.DefaultDbSchema;

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DbSet<DistrictEntity> Districts { get; set; }
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBase(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}