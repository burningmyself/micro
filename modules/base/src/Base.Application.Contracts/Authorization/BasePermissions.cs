using Volo.Abp.Reflection;

namespace Base.Authorization
{
    public class BasePermissions
    {

        public const string Home = "AbpHome";

        public class HomeModule
        {
            public const string Console = Home + ".Console";
        }


        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasePermissions));
        }
    }
}