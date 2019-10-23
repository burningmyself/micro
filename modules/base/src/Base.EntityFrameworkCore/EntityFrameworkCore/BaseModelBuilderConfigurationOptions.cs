using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Base.EntityFrameworkCore
{
    public class BaseModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public BaseModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}