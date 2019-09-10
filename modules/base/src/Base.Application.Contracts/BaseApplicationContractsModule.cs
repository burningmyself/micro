using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Base
{
    [DependsOn(
        typeof(BaseDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class BaseApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BaseApplicationContractsModule>("Base");
            });
        }
    }
}
