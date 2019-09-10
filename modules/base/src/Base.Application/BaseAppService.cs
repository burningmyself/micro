using Base.Localization;
using Volo.Abp.Application.Services;

namespace Base
{
    public abstract class BaseAppService : ApplicationService
    {
        protected BaseAppService()
        {
            LocalizationResource = typeof(BaseResource);
        }
    }
}
