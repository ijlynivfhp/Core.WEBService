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
            // 1��IOC������ע��dbcontext
            services.AddDbContextPool<SeckillContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2��ע����Ʒservice
            services.AddScoped<ISeckillService, SeckillServiceImpl>();
            services.AddScoped<ISeckillRecordService, SeckillRecordServiceImpl>();
            services.AddScoped<ISeckillTimeModelService, SeckillTimeModelServiceImpl>();

            // 3��ע����Ʒ�ִ�
            services.AddScoped<ISeckillRepository, SeckillRepository>();
            services.AddScoped<ISeckillRecordRepository, SeckillRecordRepository>();
            services.AddScoped<ISeckillTimeModelRepository, SeckillTimeModelRepository>();

            // 4����ӷ���ע��
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "SeckillServices";
                //options.ServiceAddress = "http://172.18.0.14:80";
                options.ServiceAddress = "http://10.96.0.14:5004";//k8s��Ⱥservice����
                // options.ServiceAddress = "https://localhost:5004";
                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s��Ⱥservice����
                //options.RegistryAddress = "http://localhost:8500";
            });

            // 5����ӿ�����
            services.AddControllers(options => {
                options.Filters.Add<MiddlewareResultWapper>(); // 1��ͨ�ý��
                options.Filters.Add<BizExceptionHandler>();// 2��ͨ���쳣
                options.ModelBinderProviders.Add(new SysUserModelBinderProvider());// 3���Զ���ģ�Ͱ�
            }).AddNewtonsoftJson(options => {
                // ��ֹ����дת����Сд
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 1���Զ���ϵͳ�쳣����
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
