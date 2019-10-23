using Base.UI.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Base.UI
{
    [DependsOn(
       typeof(AbpLocalizationModule)
       )]
    public class BaseUiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BaseUiModule>();
            });



            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<AbpiUiResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("Base/UI/Localization/AbpUi");
            });
        }
    }
}
