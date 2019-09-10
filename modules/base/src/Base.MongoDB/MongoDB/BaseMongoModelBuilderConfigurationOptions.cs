using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    public class BaseMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public BaseMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = BaseConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}