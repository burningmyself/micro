using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Base.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.VirtualFileSystem;

namespace Base
{
    [DependsOn(
        typeof(AbpLocalizationModule)
    )]
    public class BaseDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BaseDomainSharedModule>("Base");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BaseResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Base");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Base", typeof(BaseResource));
            });
        }
    }
}
