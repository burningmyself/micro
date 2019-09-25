using Volo.Abp.Reflection;

namespace Base.Authorization
{
    public class BasePermissions
    {




        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasePermissions));
        }
    }
}