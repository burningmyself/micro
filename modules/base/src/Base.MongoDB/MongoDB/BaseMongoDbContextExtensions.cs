using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    public static class BaseMongoDbContextExtensions
    {
        public static void ConfigureBase(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BaseMongoModelBuilderConfigurationOptions(
                BaseDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}