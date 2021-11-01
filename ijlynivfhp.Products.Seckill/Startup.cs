using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RuanMou.MicroService.SeckillRecordService.Repositories;
using RuanMou.MicroService.SeckillService.Repositories;
using RuanMou.MicroService.SeckillTimeModelService.Repositories;
using ijlynivfhp.WEBService.Commons.Exceptions.Handlers;
using ijlynivfhp.WEBService.Commons.Filter;
using ijlynivfhp.WEBService.Commons.Middlewares;
using ijlynivfhp.WEBService.Commons.Users;
using ijlynivfhp.WEBService.Cores.Registry.Extentions;
using ijlynivfhp.WEBService.SeckillRecordServices.Services;
using ijlynivfhp.WEBService.SeckillServices.Context;
using ijlynivfhp.WEBService.SeckillServices.Repositories;
using ijlynivfhp.WEBService.SeckillServices.Services;
using ijlynivfhp.WEBService.SeckillTimeServices.Services;
using System;

namespace RuanMou.Seckills.PorductServices
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
            services.AddDbContextPool<SeckillContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2、注册商品service
            services.AddScoped<ISeckillService, SeckillServiceImpl>();
            services.AddScoped<ISeckillRecordService, SeckillRecordServiceImpl>();
            services.AddScoped<ISeckillTimeModelService, SeckillTimeModelServiceImpl>();

            // 3、注册商品仓储
            services.AddScoped<ISeckillRepository, SeckillRepository>();
            services.AddScoped<ISeckillRecordRepository, SeckillRecordRepository>();
            services.AddScoped<ISeckillTimeModelRepository, SeckillTimeModelRepository>();

            // 4、添加服务注册
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "SeckillServices";
                //options.ServiceAddress = "http://172.18.0.14:80";
                options.ServiceAddress = "http://10.96.0.14:5004";//k8s集群service配置
                // options.ServiceAddress = "https://localhost:5004";
                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s集群service配置
                //options.RegistryAddress = "http://localhost:8500";
            });

            // 5、添加控制器
            services.AddControllers(options => {
                options.Filters.Add<MiddlewareResultWapper>(); // 1、通用结果
                options.Filters.Add<BizExceptionHandler>();// 2、通用异常
                options.ModelBinderProviders.Add(new SysUserModelBinderProvider());// 3、自定义模型绑定
            }).AddNewtonsoftJson(options => {
                // 防止将大写转换成小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 1、自定义系统异常处理
            app.UseSystmeException();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
