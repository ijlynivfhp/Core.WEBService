using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RuanMou.MicroService.PaymentService.Repositories;
using ijlynivfhp.WEBService.Commons.Exceptions.Handlers;
using ijlynivfhp.WEBService.Commons.Filter;
using ijlynivfhp.WEBService.Cores.Registry.Extentions;
using ijlynivfhp.WEBService.PaymentServices.Context;
using ijlynivfhp.WEBService.PaymentServices.Repositories;
using ijlynivfhp.WEBService.PaymentServices.Services;
using System;

namespace ijlynivfhp.WEBService.PaymentServices
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
            services.AddDbContext<PaymentContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2��ע��֧��service
            services.AddScoped<IPaymentService, PaymentServiceImpl>();

            // 3��ע��֧���ִ�
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // 4�����ӷ���ע��
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "PaymentServices";
                // options.ServiceAddress = "http://172.18.0.17:80";
                options.ServiceAddress = "http://10.96.0.9:5003";// k8s��Ⱥservice����
               // options.ServiceAddress = "https://localhost:5003";
                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s��Ⱥservice����
               // options.RegistryAddress = "http://localhost:8500";
            });
            // 6�����ӿ�����
            services.AddControllers(options =>
            {
                options.Filters.Add<MiddlewareResultWapper>(1);
                options.Filters.Add<BizExceptionHandler>(2);
            }).AddNewtonsoftJson(option =>
            {
                // ��ֹ����дת����Сд
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}