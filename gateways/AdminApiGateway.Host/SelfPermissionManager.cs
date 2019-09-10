using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace AdminApiGateway.Host
{
    public class SelfPermissionManager : PermissionManager
    {
        public SelfPermissionManager(IPermissionDefinitionManager permissionDefinitionManager, IPermissionGrantRepository permissionGrantRepository, IServiceProvider serviceProvider, IGuidGenerator guidGenerator, IOptions<PermissionManagementOptions> options, ICurrentTenant currentTenant) : base(permissionDefinitionManager, permissionGrantRepository, serviceProvider, guidGenerator, options, currentTenant)
        {
        }

        protected override async Task<PermissionWithGrantedProviders> GetInternalAsync(PermissionDefinition permission, string providerName, string providerKey)
        {
            var result = new PermissionWithGrantedProviders(permission.Name, false);

            if (!permission.MultiTenancySide.HasFlag(CurrentTenant.GetMultiTenancySide()))
            {
                return result;
            }

            if (permission.Providers.Any() && !permission.Providers.Contains(providerName))
            {
                return result;
            }

            foreach (var provider in ManagementProviders)
            {
                var providerResult = await provider.CheckAsync(permission.Name, provider.Name, providerKey);
                if (providerResult.IsGranted)
                {
                    result.IsGranted = true;
                    result.Providers.Add(new PermissionValueProviderInfo(provider.Name, providerResult.ProviderKey));
                }
            }

            return result;
        }
    }
}
