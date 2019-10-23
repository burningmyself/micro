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

namespace AdminApiGateway.Host
{
    [DependsOn(
        typeof(BaseHttpApiModule),
        typeof(BaseUiModule)
        )]
    public class AdminApiGatewayModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.ReportApiVersions = false;
            });
           //.AddMvcCore().Services.AddVersionedApiExplorer(option =>
           //{
           //    option.GroupNameFormat = "'v'VVV";
           //    option.AssumeDefaultVersionWhenUnspecified = true;
           //});
            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminApiGateway API", Version = "v1" });
                //options.SwaggerDoc("v2", new Info { Title = "App API", Version = "v2" });

                options.DocInclusionPredicate((docName, description) =>
                {
                    if (description.RelativePath.Contains("api-version"))
                    {
                        return false;
                    }
                    //if ("v1" == docName && description.RelativePath.Split(@"/")[0] != "App")
                    //{
                    //    return true;
                    //}
                    //if ("v2" == docName && description.RelativePath.Split(@"/")[0] == "App")
                    //{
                    //    return true;
                    //}
                    return true;
                });
                options.CustomSchemaIds(type => type.FullName);

                //var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                //options.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                //options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = "apiKey"
                //});
            });

            context.Services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "中文", flagIcon: "ios-add"));
                options.Languages.Add(new LanguageInfo("en", "en", "English", flagIcon: "ios-add"));
                //...add other languages
            });


            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "Ms-DataProtection-Keys");


        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseAuthentication();
            app.UseAbpRequestLocalization();

            app.UseCors(builder => builder
                .WithOrigins("http://localhost:9000")
                .WithOrigins("http://localhost:9527")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    foreach (var description in provider.ApiVersionDescriptions)
            //    {
            //        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            //    }
            //});
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminApiGateway API");
                //options.SwaggerEndpoint("/swagger/v2/swagger.json", "App API");
            });
            //app.MapWhen(
            //    ctx => ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
            //           ctx.Request.Path.ToString().StartsWith("/Abp/"),
            //    app2 => { app2.UseMvcWithDefaultRouteAndArea(); }
            //);           
        }
    }
}
