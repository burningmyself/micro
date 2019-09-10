using Localization.Resources.AbpUi;
using Base.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Base
{
    [DependsOn(
        typeof(BaseApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class BaseHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BaseResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
