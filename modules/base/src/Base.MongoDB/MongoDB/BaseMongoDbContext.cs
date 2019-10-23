using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    [ConnectionStringName(BaseDbProperties.ConnectionStringName)]
    public class BaseMongoDbContext : AbpMongoDbContext, IBaseMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBase();
        }
    }
}