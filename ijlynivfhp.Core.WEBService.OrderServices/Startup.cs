using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RuanMou.MicroService.OrderItemService.Repositories;
using RuanMou.MicroService.OrderService.Repositories;
using ijlynivfhp.Core.WEBService.Commons.Exceptions.Handlers;
using ijlynivfhp.Core.WEBService.Commons.Filter;
using ijlynivfhp.Core.WEBService.Cores.Middleware.Extentions;
using ijlynivfhp.Core.WEBService.Cores.Registry.Extentions;
using ijlynivfhp.Core.WEBService.OrderItemServices.Repositories;
using ijlynivfhp.Core.WEBService.OrderItemServices.Services;
using ijlynivfhp.Core.WEBService.OrderServices.Context;
using ijlynivfhp.Core.WEBService.OrderServices.Repositories;
using ijlynivfhp.Core.WEBService.OrderServices.Services;
using System;

namespace ijlynivfhp.Core.WEBService.OrderServices
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
            services.AddDbContextPool<OrderContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2��ע���û�service
            services.AddScoped<IOrderService, OrderServiceImpl>();
            services.AddScoped<IOrderItemService, OrderItemServiceImpl>();

            // 3��ע���û��ִ�
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            // 4����ӷ���ע��
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "OrderServices";
                // options.ServiceAddress = "http://172.18.0.12:80";// docker��������
                options.ServiceAddress = "http://10.96.0.8:5002";// k8s��Ⱥservice����
                // options.ServiceAddress = "https://localhost:5002";

                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";//docker��������
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s��Ⱥservice����
                // options.RegistryAddress = "http://localhost:8500";

            });

            // 6����ӿ�����
            services.AddControllers(options =>
            {
                options.Filters.Add<MiddlewareResultWapper>(1);
                options.Filters.Add<BizExceptionHandler>(2);
            }).AddNewtonsoftJson(option =>
            {
                // ��ֹ����дת����Сд
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            // 7������¼�����cap
            services.AddCap(x =>
            {
                // 7.1 ʹ��EntityFramework���д洢����
                x.UseEntityFramework<OrderContext>();
                // 7.2 ʹ��sqlserver����������
                x.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

                // 7.3 ʹ��RabbitMQ�����¼����Ĵ���
                x.UseRabbitMQ(rb =>
                {
                     rb.HostName = "localhost"; // ��������
                    // rb.HostName = "172.18.0.3";// docker����
                    rb.HostName = "10.96.0.3";// docker��Ⱥservice
                    rb.UserName = "guest";
                    rb.Password = "guest";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });
                /*x.UseKafka(kf =>
                {
                    kf.Servers = "localhost:9092";
                });*/

                // 7.4 ���ö�ʱ����������
                // x.FailedRetryInterval = 2;
                x.FailedRetryCount = 5; // 3 ��ʧ�� 3����

                // 8.5 �˹���Ԥ���޸ı��������ҳ��
                x.UseDashboard();
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
