using CSRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ijlynivfhp.WEBService.Commons.Caches
{
    /// <summary>
    /// ServiceCollection Redis扩展
    /// </summary>
    public static class RedisServiceCollectionExtensions
    {
        /// <summary>
        ///  注册分布式Redis缓存
        /// </summary>
        /// <typeparam name="connectionString"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddDistributedRedisCache(this IServiceCollection services,string connectionString)
        {
            // 1、创建redis客户端实例
            // var csredis = new CSRedisClient("127.0.0.1:6379,password=,defaultDatabase=2,poolsize=50,connectTimeout=5000,syncTimeout=10000,prefix=cs_redis_");
            var csredis = new CSRedisClient(connectionString);
            // 2、注册RedisClient到IOC
            services.AddSingleton(csredis);

            // 3、添加到redis帮助类
            RedisHelper.Initialization(csredis);//初始化
            return services;
        }

        /// <summary>
        ///  注册分布式Redis集群缓存
        /// </summary>
        /// <typeparam name="connectionString"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddDistributedRedisCache(this IServiceCollection services, string[] connectionString)
        {
            // 1、创建redis客户端实例
            var csredis = new CSRedisClient((d) => { return ""; },connectionString);

            // 2、注册RedisClient到IOC
            services.AddSingleton(csredis);

            // 3、添加到redi帮助类
            RedisHelper.Initialization(csredis);//初始化
            return services;
        }
    }
}
