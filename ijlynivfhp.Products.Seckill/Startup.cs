using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ijlynivfhp.MicroService.SeckillRecordService.Repositories;
using ijlynivfhp.MicroService.SeckillService.Repositories;
using ijlynivfhp.MicroService.SeckillTimeModelService.Repositories;
using ijlynivfhp.Projects.Commons.Exceptions.Handlers;
using ijlynivfhp.Projects.Commons.Filter;
using ijlynivfhp.Projects.Commons.Middlewares;
using ijlynivfhp.Projects.Commons.Users;
using ijlynivfhp.Projects.Cores.Registry.Extentions;
using ijlynivfhp.Projects.SeckillRecordServices.Services;
using ijlynivfhp.Projects.SeckillServices.Context;
using ijlynivfhp.Projects.SeckillServices.Repositories;
using ijlynivfhp.Projects.SeckillServices.Services;
using ijlynivfhp.Projects.SeckillTimeServices.Services;
using System;

namespace ijlynivfhp.Seckills.PorductServices
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
                options.RegistryAddress = "http://localhost:8500";//k8s��Ⱥservice����
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
