using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Base.EntityFrameworkCore
{
    public class BaseModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public BaseModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = BaseConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = BaseConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}