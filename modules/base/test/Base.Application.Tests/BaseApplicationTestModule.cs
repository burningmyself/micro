using Volo.Abp.Modularity;

namespace Base
{
    [DependsOn(
        typeof(BaseApplicationModule),
        typeof(BaseDomainTestModule)
        )]
    public class BaseApplicationTestModule : AbpModule
    {

    }
}
