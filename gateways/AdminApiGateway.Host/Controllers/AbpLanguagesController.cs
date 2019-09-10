using AdminApiGateway.Host.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;

namespace AdminApiGateway.Host.Controllers
{
    [Route("api/abp/language/[action]")]
    public class AbpLanguagesController : AbpController
    {
        private readonly ConfigurationAppService _applicationConfigurationAppService;

        public AbpLanguagesController(
            ConfigurationAppService applicationConfigurationAppService)
        {
            _applicationConfigurationAppService = applicationConfigurationAppService;
        }

        [HttpGet]
        public IActionResult Switch(string culture, string uiCulture = "")
        {
            if (!IsValidCultureCode(culture))
            {
                throw new AbpException("Unknown language: " + culture + ". It must be a valid culture!");
            }

            string cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, uiCulture));

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cookieValue, new CookieOptions
            {
                Expires = Clock.Now.AddYears(2)
            });
            return Ok();
        }
        [HttpGet]
        public Task<ApplicationLocalizationConfigurationDto> Localization()
        {
            return _applicationConfigurationAppService.LocalizationAsync();
        }

        private static bool IsValidCultureCode(string cultureCode)
        {
            if (cultureCode.IsNullOrWhiteSpace())
            {
                return false;
            }

            try
            {
                CultureInfo.GetCultureInfo(cultureCode);
                return true;
            }
            catch (CultureNotFoundException)
            {
                return false;
            }
        }
    }
}
