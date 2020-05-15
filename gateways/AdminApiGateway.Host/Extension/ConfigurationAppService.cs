using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations.ObjectExtending;
using Volo.Abp.Authorization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Users;

namespace AdminApiGateway.Host.Extension
{
    public class ConfigurationAppService : AbpApplicationConfigurationAppService
    {
        public ConfigurationAppService(IOptions<AbpLocalizationOptions> localizationOptions, IOptions<AbpMultiTenancyOptions> multiTenancyOptions, IServiceProvider serviceProvider, IAbpAuthorizationPolicyProvider abpAuthorizationPolicyProvider, IAuthorizationService authorizationService, ICurrentUser currentUser, ISettingProvider settingProvider, ISettingDefinitionManager settingDefinitionManager, IFeatureDefinitionManager featureDefinitionManager, ILanguageProvider languageProvider, ICachedObjectExtensionsDtoService cachedObjectExtensionsDtoService) : base(localizationOptions, multiTenancyOptions, serviceProvider, abpAuthorizationPolicyProvider, authorizationService, currentUser, settingProvider, settingDefinitionManager, featureDefinitionManager, languageProvider, cachedObjectExtensionsDtoService)
        {
        }

        public async Task<ApplicationLocalizationConfigurationDto> LocalizationAsync()
        {
            return await GetLocalizationConfigAsync();
        }
    }
}
