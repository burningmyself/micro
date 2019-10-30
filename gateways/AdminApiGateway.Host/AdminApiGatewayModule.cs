using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Base;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Base.UI;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Linq;

namespace AdminApiGateway.Host
{
    [DependsOn(
        typeof(BaseHttpApiModule),
        typeof(BaseUiModule)
        )]
    public class AdminApiGatewayModule : AbpModule
    {
        // 默认的跨域请求策略名称
        private const string _defaultCorsPolicyName = "Admin.Api.Cors";
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAuthentication("Bearer")
                 .AddIdentityServerAuthentication(options =>
                 {
                     options.Authority = configuration["AuthServer:Authority"];
                     options.ApiName = configuration["AuthServer:ApiName"];
                     options.RequireHttpsMetadata = false;
                    //TODO: Should create an extension method for that (may require to create a new ABP package depending on the IdentityServer4.AccessTokenValidation)
                    //options.InboundJwtClaimTypeMap["sub"] = AbpClaimTypes.UserId;
                    //options.InboundJwtClaimTypeMap["role"] = AbpClaimTypes.Role;
                    //options.InboundJwtClaimTypeMap["email"] = AbpClaimTypes.Email;
                    //options.InboundJwtClaimTypeMap["email_verified"] = AbpClaimTypes.EmailVerified;
                    //options.InboundJwtClaimTypeMap["phone_number"] = AbpClaimTypes.PhoneNumber;
                    //options.InboundJwtClaimTypeMap["phone_number_verified"] = AbpClaimTypes.PhoneNumberVerified;
                    //options.InboundJwtClaimTypeMap["name"] = AbpClaimTypes.UserName;
                });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminApiGateway Gateway API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
            context.Services.AddOcelot(context.Services.GetConfiguration());

            //Configure<AbpDbContextOptions>(options =>
            //{
            //    options.UseSqlServer();
            //});

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "中文", flagIcon: "ios-add"));
                options.Languages.Add(new LanguageInfo("en", "en", "English", flagIcon: "ios-add"));
                //...add other languages
            });

            context.Services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });           

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Ms-DataProtection-Keys");

            #region "配置 CORS 授权策略"
            context.Services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
            builder => builder.WithOrigins(
                    configuration["AllowedHosts"]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray()
                )
            .AllowAnyHeader()
            .AllowAnyMethod()));
            #endregion
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            // 允许跨域请求访问
            app.UseCors(_defaultCorsPolicyName);
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminApiGateway Gateway API");
            });

            //app.MapWhen(
            //    ctx => ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
            //           ctx.Request.Path.ToString().StartsWith("/Abp/"),
            //    app2 => { app2.UseMvcWithDefaultRouteAndArea(); }
            //);

            app.UseOcelot().Wait();

        }
    }
}
