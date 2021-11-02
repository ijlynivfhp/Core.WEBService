using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ijlynivfhp.MicroService.UserService.Repositories;
using ijlynivfhp.Projects.Commons.Exceptions.Handlers;
using ijlynivfhp.Projects.Commons.Filter;
using ijlynivfhp.Projects.Cores.Registry.Extentions;
using ijlynivfhp.Projects.UserServices.Configs;
using ijlynivfhp.Projects.UserServices.Context;
using ijlynivfhp.Projects.UserServices.IdentityServer;
using ijlynivfhp.Projects.UserServices.Repositories;
using ijlynivfhp.Projects.UserServices.Services;
using System;
using System.Linq;
using System.Reflection;

namespace ijlynivfhp.Projects.UserServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 1、IOC容器中注入dbcontext
            services.AddDbContext<UserContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2、注册用户service
            services.AddScoped<IUserService, UserServiceImpl>();

            // 3、注册用户仓储
            services.AddScoped<IUserRepository, UserRepository>();

            // services.AddMiddleware<IMiddleService,MiddleService>();

            // 4、添加服务注册
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "UserServices";
                // options.ServiceAddress = "http://172.18.0.13:80";
                options.ServiceAddress = "http://10.96.0.11:5005";//k8s集群service配置
                //options.ServiceAddress = "https://localhost:5005";
                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s集群service配置
                //options.RegistryAddress = "http://localhost:8500";
            });
           // var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            // 5、添加IdentityServer4
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()// 1、配置签署证书
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    {
                        builder.UseMySQL(Configuration.GetConnectionString("DefaultConnection")/*, options =>
                             options.MigrationsAssembly(migrationsAssembly)*/);
                    };
                })
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();// 2、自定义用户校验

            // 6、添加控制器
            services.AddControllers(options =>
            {
                options.Filters.Add<MiddlewareResultWapper>(1);
                options.Filters.Add<BizExceptionHandler>(2);
            }).AddNewtonsoftJson(option =>
            {
                // 防止将大写转换成小写
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // 2、使用IdentityServer
            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
        }


        // 1、将config中数据存储起来
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.Ids)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
