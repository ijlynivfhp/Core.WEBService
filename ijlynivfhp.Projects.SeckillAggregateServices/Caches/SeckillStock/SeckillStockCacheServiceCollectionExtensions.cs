using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 秒杀库存使用IOC容器触发
    /// </summary>
    public static class SeckillStockCacheServiceCollectionExtensions
    {
        /// <summary>
        /// 添加秒杀库存到Cache
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddSeckillStockCache(this IServiceCollection services)
        {
            // 1、注册SeckillStockCache
            services.AddSingleton<ISeckillStockCache,SeckillStockCache>();

            // 2、注册SeckillStockCacheHostedService
            services.AddHostedService<SeckillStockCacheHostedService>();
            return services;
        }

        /// <summary>
        /// 添加秒杀库存到redis
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRedisSeckillStockCache(this IServiceCollection services)
        {
            // 1、注册SeckillStockCache
            services.AddSingleton<ISeckillStockCache, RedisSeckillStockCache>();

            // 2、注册SeckillStockCacheHostedService
            services.AddHostedService<SeckillStockCacheHostedService>();
            return services;
        }

    }
}
