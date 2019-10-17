using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Base.IdentityServer
{
    public static class UserManagerExtensions
    {
        /// <summary>
        /// 修改用户密码，无需提供用户当前密码
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="user">要修改密码的用户对象</param>
        /// <param name="password">修改后的密码</param>
        /// <returns></returns>
        public static async Task<IdentityResult> ChangePasswordAsync1(this UserManager<Volo.Abp.Identity.IdentityUser> userManager, Volo.Abp.Identity.IdentityUser user, string password)
        {
            var type = userManager.GetType();
            var storeProperty = type.GetProperty("Store", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var store = storeProperty.GetValue(userManager) as IUserPasswordStore<Volo.Abp.Identity.IdentityUser>;
            if (store == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "NotImplements", Description = "持久化存储器没有实现IUserPasswordStore接口" });
            }
            var passwordHash = userManager.PasswordHasher.HashPassword(user, password);
            await store.SetPasswordHashAsync(user, passwordHash, System.Threading.CancellationToken.None);
            await store.UpdateAsync(user, System.Threading.CancellationToken.None);
            return IdentityResult.Success;
        }
    }
}