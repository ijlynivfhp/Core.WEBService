using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 服务启动加载秒杀Lua文件
    /// </summary>
    public class SeckillLuaHostedService : IHostedService
    {
        private readonly IMemoryCache memoryCache;

        public SeckillLuaHostedService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        /// <summary>
        /// 加载秒杀库存缓存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("加载执行lua文件到redis中");
                // 1、加载lua到redis
                FileStream fileStream = new FileStream(@"Luas/SeckillLua.lua", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadToEnd();
                    string luaSha = RedisHelper.ScriptLoad(@line);

                    // 2、保存luaSha到缓存中
                    memoryCache.Set<string>("luaSha", luaSha);
                }

                Console.WriteLine("加载回滚lua文件到redis中");
                // 1、加载lua到redis
                FileStream fileStreamCallback = new FileStream(@"Luas/SeckillLuaCallback.lua", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStreamCallback))
                {
                    string line = reader.ReadToEnd();
                    string luaSha = RedisHelper.ScriptLoad(@line);

                    // 2、保存luaShaCallback到缓存中
                    memoryCache.Set<string>("luaShaCallback", luaSha);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"lua文件异常:{e.Message}");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
