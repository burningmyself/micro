using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Base.MongoDB
{
    public static class BaseMongoDbContextExtensions
    {
        public static void ConfigureBase(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BaseMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}