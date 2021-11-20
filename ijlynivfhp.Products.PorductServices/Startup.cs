using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ijlynivfhp.MicroService.ProductService.Repositories;
using ijlynivfhp.Projects.Commons.Exceptions.Handlers;
using ijlynivfhp.Projects.Commons.Filter;
using ijlynivfhp.Projects.Cores.Registry.Extentions;
using ijlynivfhp.Projects.ProductImageServices.Services;
using ijlynivfhp.Projects.ProductServices.Context;
using ijlynivfhp.Projects.ProductServices.Repositories;
using ijlynivfhp.Projects.ProductServices.Services;
using System;

namespace ijlynivfhp.Products.PorductServices
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
            services.AddDbContext<ProductContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // 2、注册商品service
            services.AddScoped<IProductService, ProductServiceImpl>();
            services.AddScoped<IProductImageService, ProductImageServiceImpl>();

            // 3、注册商品仓储
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();

            // 4、添加服务注册
            services.AddServiceRegistry(options => {
                options.ServiceId = Guid.NewGuid().ToString();
                options.ServiceName = "ProductServices";
                //options.ServiceAddress = "http://172.18.0.11:80";
                options.ServiceAddress = "http://10.96.0.7:5001"; //k8s集群service配置
                //options.ServiceAddress = "https://localhost:5001";
                options.HealthCheckAddress = "/HealthCheck";

                // options.RegistryAddress = "http://172.18.0.2:8500";
                options.RegistryAddress = "http://localhost:8500";//k8s集群service配置
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
