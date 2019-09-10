using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Base
{
    [DependsOn(
        typeof(BaseApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class BaseHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Base";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BaseApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
