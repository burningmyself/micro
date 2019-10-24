using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account.Web.Areas.Account.Controllers.Models;
using Volo.Abp.Identity;
using Volo.Abp.Validation;
using Volo.Abp.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using System.Linq;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Uow;
using Base.IdentityServer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.IdentityModel;
using IdentityModel;
using System.Net.Http;

namespace Base.Controllers
{

    public class RoleDto : IdentityRoleDto
    {

        public List<string> grantPermission = new List<string>();
    }


    public class RolePerssionReq : EntityDto<Guid>
    {

        public string Name { get; set; }

        public List<string> grantPermission
        {
            get; set;
        }

    }

    /// <summary>
    /// 用户权限及角色
    /// </summary>
    public class RoleAndPermissionByUser : RolePerssionReq
    {
        public string[] grantRoles
        {
            get; set;
        }
    }


    public class UserRole : IdentityUserRole
    {
        public UserRole(Guid UserId, Guid RoleId)
        {
            this.UserId = UserId;
            this.RoleId = RoleId;
        }
    }
    public class UpdateOrCreateUserDto : EntityDto<Guid>
    {

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }

        public string[] Permissions { get; set; }
    }



    [RemoteService]
    [Route("/api/[controller]/[action]")]
    public class AccountController : AbpController
    {

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _Uu;
        private readonly IdentityUserManager _userManager;
        private readonly IdentityRoleManager _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTenant _currentTenant;
        private readonly AbpAspNetCoreMultiTenancyOptions _aspNetCoreMultiTenancyOptions;
        private readonly IProfileAppService _profileAppService;
        private readonly IIdentityRoleAppService _roleAppService;
        private readonly IIdentityUserAppService _userAppService;
        private readonly IAbpAuthorizationPolicyProvider _abpAuthorizationPolicyProvider;
        private readonly IAbpAuthorizationService _authorizationService;
        private readonly IPermissionDefinitionManager _permissionDefinitionManager;
        private readonly IRepository<PermissionGrant> _permissionGrant;
        private readonly IRepository<IdentityUser> _identityUser;
        private readonly IRepository<IdentityRole> _identityRole;


        public AccountController(IdentityUserManager userManager,
            IConfiguration configuration,
            ICurrentTenant currentTenant,
            IdentityRoleManager roleManager,
            IOptions<AbpAspNetCoreMultiTenancyOptions> options,
            IProfileAppService profileAppService,
            IRepository<IdentityUser> identityUser,
            IIdentityRoleAppService roleAppService,
            IIdentityUserAppService userAppService,
            IAbpAuthorizationPolicyProvider abpAuthorizationPolicyProvider,
            IAbpAuthorizationService authorizationService,
            IRepository<PermissionGrant> permissionGrant,
            IPermissionDefinitionManager permissionDefinitionManager,
            IRepository<IdentityRole> identityRole,
           Microsoft.AspNetCore.Identity.UserManager<IdentityUser> Uu
            )
        {
            _userManager = userManager;
            _Uu = Uu;
            _currentTenant = currentTenant;
            _aspNetCoreMultiTenancyOptions = options.Value;
            _configuration = configuration;
            _profileAppService = profileAppService;
            _roleAppService = roleAppService;
            _userAppService = userAppService;
            _abpAuthorizationPolicyProvider = abpAuthorizationPolicyProvider;
            _authorizationService = authorizationService;
            _permissionDefinitionManager = permissionDefinitionManager;
            _permissionGrant = permissionGrant;
            _identityUser = identityUser;
            _identityRole = identityRole;

            _roleManager = roleManager;
        }


        [HttpGet("permission/{Id:guid}")]
        public async Task<IEnumerable<string>> getUserGrantPermission([FromRoute]string Id) =>
             //获取当前user权限
             _permissionGrant.Where(res => res.ProviderName == "User" && res.ProviderKey == Id).ToList().Select(res => res.Name);


        [UnitOfWork]
        [HttpPost("userPermission")]
        public async Task updateUserIsRoleAndPermission([FromBody]RoleAndPermissionByUser req)
        {
            string uId = req.Id.ToString();
            //清除当前user权限
            await _permissionGrant.DeleteAsync(res => res.ProviderName == "User" && res.ProviderKey == uId);
            //添加当前用户权限
            await addUserPermission(req.grantPermission, uId);
            //添加当前角色
            await _userAppService.UpdateRolesAsync(req.Id, new IdentityUserUpdateRolesDto() { RoleNames = req.grantRoles });
        }


        private async Task addUserPermission(IEnumerable<string> req, string uId)
        {
            req.ToList().ForEach(async res =>
            {
                await _permissionGrant.InsertAsync(new PermissionGrant(Guid.NewGuid(), res, "User", uId));
            });
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [UnitOfWork]
        [HttpPost("createUser")]
        public async Task<bool> CreateUser([FromBody]UpdateOrCreateUserDto req)
        {
            var dto = await _userAppService.CreateAsync(new IdentityUserCreateDto()
            {
                Email = req.Email,
                UserName = req.UserName,
                RoleNames = req.Roles,
                Password = "1q2w3E*",
                PhoneNumber = req.PhoneNumber
            });

            var user = await _identityUser.FirstOrDefaultAsync(x => x.Id == dto.Id);


            await UserManagerExtensions.ChangePasswordAsync1(_Uu, user, req.Password);


            await _permissionGrant.DeleteAsync(r => r.ProviderName == "user" && r.ProviderKey == user.Id.ToString());
            foreach (var item in req.Permissions)
            {
                await _permissionGrant.InsertAsync(new PermissionGrant(Guid.NewGuid(), item, "User", user.Id.ToString()));
            }

            return true;
        }




        /// <summary>
        /// 获取角色 --带权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ListResultDto<RoleDto>> getRolesAndGrantPermission([FromQuery]PagedAndSortedResultRequestDto req)
        {
            //返回数据
            var resultDto = new ListResultDto<RoleDto>();
            //分页获取角色
            var roleData = JsonConvert.DeserializeObject<List<RoleDto>>(JsonConvert.SerializeObject(_identityRole
                .AsQueryable().Skip(req.SkipCount).Take(req.MaxResultCount).ToList()));
            //获取所有role权限
            var permissionRoleData = _permissionGrant.Where(res => res.ProviderName == "Role").ToList();
            foreach (var role in roleData)
            {
                foreach (var permission in permissionRoleData)
                {
                    if (role.Name == permission.ProviderKey)
                    {
                        role.grantPermission?.Add(permission.Name);
                    }
                }
            }
            return new ListResultDto<RoleDto>()
            {
                Items = roleData
            };
        }

        /// <summary>
        /// 修改用户信息，角色，用户权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [UnitOfWork]
        [HttpPost("updateUser")]
        public async Task<bool> UpdateUser([FromBody]UpdateOrCreateUserDto req)
        {
            //update password
            // await _userManager.AddPasswordAsync(await _userManager.GetByIdAsync(req.Id), req.Password);

            //update info
            var user = await _identityUser.FirstOrDefaultAsync(x => x.Id == req.Id);

            await _userManager.SetUserNameAsync(user, req.UserName);

            await _userManager.SetEmailAsync(user, req.Email);

            await _userManager.SetPhoneNumberAsync(user, req.PhoneNumber);

            await _userManager.SetRolesAsync(user, req.Roles);
            if (!req.Password.Contains("AQAAAAEAACcQAAAAE"))
                await UserManagerExtensions.ChangePasswordAsync1(_Uu, user, req.Password);

            //update user permission

            await _permissionGrant.DeleteAsync(r => r.ProviderName == "user" && r.ProviderKey == req.Id.ToString());
            foreach (var item in req.Permissions)
            {
                await _permissionGrant.InsertAsync(new PermissionGrant(Guid.NewGuid(), item, "User", req.Id.ToString()));
            }

            return true;
        }


        [UnitOfWork]
        [HttpPost]
        public async Task UpdateRoleGrantPermission([FromBody]RolePerssionReq req)
        {
            //get当前角色
            IdentityRole role = await _identityRole.FirstOrDefaultAsync(res => res.Id == req.Id);
            //await _roleManager.SetRoleNameAsync(role, req.Name);
            //清楚当前用户所有权限
            await _permissionGrant.DeleteAsync(r => r.ProviderKey == role.Name);
            //加入权限
            req.grantPermission.ForEach(async res =>
            {
                await _permissionGrant.InsertAsync(new PermissionGrant(Guid.NewGuid(), res, "Role", role.Name));
            });
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }


        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(UserLoginInfo login)
        {
            if (!ValidationHandler.IsValidEmailAddress(login.UserNameOrEmailAddress))
            {
                return;
            }

            var userByUsername = await _userManager.FindByNameAsync(login.UserNameOrEmailAddress);
            if (userByUsername != null)
            {
                return;
            }

            var userByEmail = await _userManager.FindByEmailAsync(login.UserNameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            if (userByEmail.EmailConfirmed == false)
            {
                throw new UserFriendlyException("邮件未激活确认,无法使用邮件进行登录!");
            }

            login.UserNameOrEmailAddress = userByEmail.UserName;
        }

       
        /// <summary>
        /// scope传递offline_access，可得到refresh_token值
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Token(UserLoginInfo login)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(_configuration["AuthServer:Authority"]);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return Json(new { code = 0, data = disco.Error });
            }
            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _configuration["AuthServer:ClientId"],
                ClientSecret = _configuration["AuthServer:ClientSecret"],
                GrantType = OidcConstants.GrantTypes.Password,
                UserName = login.UserNameOrEmailAddress,
                Password = login.Password,
                Scope = "Base"
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return Json(new
                {
                    code = 0,
                    data = tokenResponse.ErrorDescription,
                    message = tokenResponse.Error
                });
            }
            return Json(new { code = 1, data = tokenResponse.Json });
        }


        [HttpPost]
        public async Task<IActionResult> Info()
        {
            var profile = await _profileAppService.GetAsync();
            //var user = await _userAppService.GetAsync(CurrentUser.GetId());
            var roles = await _userAppService.GetRolesAsync(CurrentUser.GetId());

            var auth = await GetAuthConfigAsync();

            var data = new Dictionary<string, object>(3);
            data.Add("profile", profile);
            data.Add("roles", roles.Items);
            data.Add("auth", auth);

            return Json(new { code = 1, data = data });
        }
        private async Task<ApplicationAuthConfigurationDto> GetAuthConfigAsync()
        {
            var authConfig = new ApplicationAuthConfigurationDto();
            foreach (var policyName in await _abpAuthorizationPolicyProvider.GetPoliciesNamesAsync())
            {
                authConfig.Policies[policyName] = true;

                if (await _authorizationService.IsGrantedAsync(policyName))
                {
                    authConfig.GrantedPolicies[policyName] = true;
                }
            }

            foreach (var group in _permissionDefinitionManager.GetGroups())
            {
                authConfig.Policies[group.Name] = true;


                authConfig.GrantedPolicies[group.Name] = true;
            }

            return authConfig;
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            return Json(new { code = 1, data = "{msg:'success'}" });
        }
    }
}
