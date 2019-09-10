using Base.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Base
{
    public abstract class BaseController : AbpController
    {
        protected BaseController()
        {
            LocalizationResource = typeof(BaseResource);
        }
    }
}
