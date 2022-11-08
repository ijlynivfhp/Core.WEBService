using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ijlynivfhp.Projects.Commons.Caches;
using ijlynivfhp.Projects.Commons.Distributes;
using ijlynivfhp.Projects.Commons.Exceptions.Handlers;
using ijlynivfhp.Projects.Commons.Filter;
using ijlynivfhp.Projects.Commons.Users;
using ijlynivfhp.Projects.Cores.Cluster.Extentions;
using ijlynivfhp.Projects.Cores.Middleware;
using ijlynivfhp.Projects.Cores.Middleware.Extentions;
using ijlynivfhp.Projects.Cores.Proxy.Extentions;
using ijlynivfhp.Projects.Cores.Registry.Extentions;
using ijlynivfhp.Projects.SeckillAggregateServices.Caches.SeckillStock;
using ijlynivfhp.Projects.UserServices.Context;

namespace ijlynivfhp.Projects.SeckillAggregateServices
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
            // 1、注册服务发现
            services.AddMicroClient(options =>
            {
                options.AssmelyName = "ijlynivfhp.Projects.SeckillAggregateServices";
                options.dynamicMiddlewareOptions = mo =>
                {
                    mo.serviceDiscoveryOptions = sdo =>
                    // { sdo.DiscoveryAddress = "http://172.18.0.2:8500"; };
                    { sdo.DiscoveryAddress = "http://localhost:8500"; };
                    //{ sdo.DiscoveryAddress = "http://10.96.0.2:8500"; };// k8s注册中心
                };
            });

            /*// 1、服务发现
            services.AddServiceDiscovery(options => {
                options.DiscoveryAddress = "http://localhost:8500";
            });

            // 2、注册负载均衡
            services.AddLoadBalance();*/

            // 3、注册动态
            /* services.AddDynamicMiddleware<IDynamicMiddleService, DefaultDynamicMiddleService>(options => {
                 options.serviceDiscoveryOptions = options => { options.DiscoveryAddress = "http://localhost:8500"; };
             });*/

            // 3、设置跨域
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                 builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });

            // 4、添加身份认证
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                         options.Authority = "https://localhost:5005"; // 1、授权中心地址
                        // options.Authority = "http://172.18.0.13:80"; // 1、授权中心地址
                         options.Authority = "http://10.96.0.11:5005"; // 1、k8s授权中心地址
                        options.ApiName = "TeamService"; // 2、api名称(项目具体名称)
                        options.RequireHttpsMetadata = false; // 3、https元数据，不需要
                    });

            // 5、添加控制器
            services.AddControllers(options => {
                options.Filters.Add<FrontResultWapper>(); // 1、通用结果
                options.Filters.Add<BizExceptionHandler>();// 2、通用异常
                options.ModelBinderProviders.Insert(0,new SysUserModelBinderProvider());// 3、自定义模型绑定
            }).AddNewtonsoftJson(options => {
                // 防止将大写转换成小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // 6、使用内存缓存
             services.AddMemoryCache();
            // 6.1 使用redis分布式缓存
            services.AddDistributedRedisCache("127.0.0.1:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_:");
            //services.AddDistributedRedisCache("172.18.0.19:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_");
            //services.AddDistributedRedisCache("10.96.0.6:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_");// k8s redis

            // 7、使用秒杀库存缓存
            // services.AddSeckillStockCache();
            // 7.1 使用秒杀redis库存缓存
            services.AddRedisSeckillStockCache();

            // 8、添加事件总线cap
            services.AddCap(x =>
            {
                // 8.1 使用内存存储消息(消息发送失败处理)
                x.UseInMemoryStorage();
                // 8.2 使用EntityFramework进行存储操作
               //  x.UseEntityFramework<SeckillAggregateServicesContext>();
                // 8.3 使用sqlserver进行事务处理
                 // x.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                // 8.4 使用RabbitMQ进行事件中心处理
                x.UseRabbitMQ(rb =>
                {
                    rb.HostName = "localhost"; // 本地主机
                    //rb.HostName = "172.18.0.3";// 远程主机
                    //rb.HostName = "10.96.0.3";// K8s集群service
                    rb.UserName = "sa";
                    rb.Password = "123456";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });

                // 8.5添加cap后台监控页面(人工处理)
                x.UseDashboard();
            });

            services.AddDbContextPool<SeckillAggregateServicesContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });


            // 9、加载seckillLua文件
            services.AddHostedService<SeckillLuaHostedService>();

            // 10、添加分布式订单
            services.AddDistributedOrderSn(1,1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/

            app.UseHttpsRedirection();

            app.UseRouting();

            // 1、开启身份认证
            app.UseAuthentication();
            app.UseAuthorization();
            // 2、使用跨域
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
