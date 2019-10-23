using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    public class BaseMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BaseMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}