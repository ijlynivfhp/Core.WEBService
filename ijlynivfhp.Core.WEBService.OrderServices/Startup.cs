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
            // 1、IOC容器中注入dbcontext
            services.AddDbContextPool<OrderContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2、注册用户service
            services.AddScoped<IOrderService, OrderServiceImpl>();
            services.AddScoped<IOrderItemService, OrderItemServiceImpl>();

            // 3、注册用户仓储
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            // 4、添加服务注册
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "OrderServices";
                // options.ServiceAddress = "http://172.18.0.12:80";// docker单机配置
                options.ServiceAddress = "http://10.96.0.8:5002";// k8s集群service配置
                // options.ServiceAddress = "https://localhost:5002";

                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";//docker单机配置
                options.RegistryAddress = "http://10.96.0.2:8500";//k8s集群service配置
                // options.RegistryAddress = "http://localhost:8500";

            });

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


            // 7、添加事件总线cap
            services.AddCap(x =>
            {
                // 7.1 使用EntityFramework进行存储操作
                x.UseEntityFramework<OrderContext>();
                // 7.2 使用sqlserver进行事务处理
                x.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

                // 7.3 使用RabbitMQ进行事件中心处理
                x.UseRabbitMQ(rb =>
                {
                     rb.HostName = "localhost"; // 本地主机
                    // rb.HostName = "172.18.0.3";// docker主机
                    rb.HostName = "10.96.0.3";// docker集群service
                    rb.UserName = "guest";
                    rb.Password = "guest";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });
                /*x.UseKafka(kf =>
                {
                    kf.Servers = "localhost:9092";
                });*/

                // 7.4 配置定时器尽早启动
                // x.FailedRetryInterval = 2;
                x.FailedRetryCount = 5; // 3 次失败 3分钟

                // 8.5 人工干预，修改表，后面管理页面
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
