using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Base
{
    [DependsOn(
        typeof(BaseHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BaseConsoleApiClientModule : AbpModule
    {
        
    }
}
