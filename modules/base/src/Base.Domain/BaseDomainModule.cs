using Volo.Abp.Modularity;

namespace Base
{
    [DependsOn(
        typeof(BaseDomainSharedModule)
        )]
    public class BaseDomainModule : AbpModule
    {

    }
}
