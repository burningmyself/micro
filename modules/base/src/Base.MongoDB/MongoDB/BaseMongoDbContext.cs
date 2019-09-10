using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    [ConnectionStringName("Base")]
    public class BaseMongoDbContext : AbpMongoDbContext, IBaseMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = BaseConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBase(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}