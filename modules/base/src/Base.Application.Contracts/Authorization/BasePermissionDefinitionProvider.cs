using Base.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Base.Authorization
{
    public class BasePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var homeModule = context.AddGroup(BasePermissions.Home);

            homeModule.AddPermission(BasePermissions.HomeModule.Console);

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BaseResource>(name);
        }
    }
}