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
            // 1��ע�������
            services.AddMicroClient(options =>
            {
                options.AssmelyName = "ijlynivfhp.Projects.SeckillAggregateServices";
                options.dynamicMiddlewareOptions = mo =>
                {
                    mo.serviceDiscoveryOptions = sdo =>
                    // { sdo.DiscoveryAddress = "http://172.18.0.2:8500"; };
                    { sdo.DiscoveryAddress = "http://localhost:8500"; };
                    //{ sdo.DiscoveryAddress = "http://10.96.0.2:8500"; };// k8sע������
                };
            });

            /*// 1��������
            services.AddServiceDiscovery(options => {
                options.DiscoveryAddress = "http://localhost:8500";
            });

            // 2��ע�Ḻ�ؾ���
            services.AddLoadBalance();*/

            // 3��ע�ᶯ̬
            /* services.AddDynamicMiddleware<IDynamicMiddleService, DefaultDynamicMiddleService>(options => {
                 options.serviceDiscoveryOptions = options => { options.DiscoveryAddress = "http://localhost:8500"; };
             });*/

            // 3�����ÿ���
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                 builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });

            // 4����������֤
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                         options.Authority = "https://localhost:5005"; // 1����Ȩ���ĵ�ַ
                        // options.Authority = "http://172.18.0.13:80"; // 1����Ȩ���ĵ�ַ
                         options.Authority = "http://10.96.0.11:5005"; // 1��k8s��Ȩ���ĵ�ַ
                        options.ApiName = "TeamService"; // 2��api����(��Ŀ��������)
                        options.RequireHttpsMetadata = false; // 3��httpsԪ���ݣ�����Ҫ
                    });

            // 5����ӿ�����
            services.AddControllers(options => {
                options.Filters.Add<FrontResultWapper>(); // 1��ͨ�ý��
                options.Filters.Add<BizExceptionHandler>();// 2��ͨ���쳣
                options.ModelBinderProviders.Insert(0,new SysUserModelBinderProvider());// 3���Զ���ģ�Ͱ�
            }).AddNewtonsoftJson(options => {
                // ��ֹ����дת����Сд
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // 6��ʹ���ڴ滺��
             services.AddMemoryCache();
            // 6.1 ʹ��redis�ֲ�ʽ����
            services.AddDistributedRedisCache("127.0.0.1:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_:");
            //services.AddDistributedRedisCache("172.18.0.19:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_");
            //services.AddDistributedRedisCache("10.96.0.6:6379, password =, defaultDatabase = 2, poolsize = 50, connectTimeout = 5000, syncTimeout = 10000, prefix = seckill_stock_");// k8s redis

            // 7��ʹ����ɱ��滺��
            // services.AddSeckillStockCache();
            // 7.1 ʹ����ɱredis��滺��
            services.AddRedisSeckillStockCache();

            // 8������¼�����cap
            services.AddCap(x =>
            {
                // 8.1 ʹ���ڴ�洢��Ϣ(��Ϣ����ʧ�ܴ���)
                x.UseInMemoryStorage();
                // 8.2 ʹ��EntityFramework���д洢����
               //  x.UseEntityFramework<SeckillAggregateServicesContext>();
                // 8.3 ʹ��sqlserver����������
                 // x.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                // 8.4 ʹ��RabbitMQ�����¼����Ĵ���
                x.UseRabbitMQ(rb =>
                {
                    rb.HostName = "localhost"; // ��������
                    //rb.HostName = "172.18.0.3";// Զ������
                    //rb.HostName = "10.96.0.3";// K8s��Ⱥservice
                    rb.UserName = "sa";
                    rb.Password = "123456";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });

                // 8.5���cap��̨���ҳ��(�˹�����)
                x.UseDashboard();
            });

            services.AddDbContextPool<SeckillAggregateServicesContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });


            // 9������seckillLua�ļ�
            services.AddHostedService<SeckillLuaHostedService>();

            // 10����ӷֲ�ʽ����
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

            // 1�����������֤
            app.UseAuthentication();
            app.UseAuthorization();
            // 2��ʹ�ÿ���
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
