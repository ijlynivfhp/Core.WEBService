using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 服务启动时，加载秒杀库存到缓存
    /// </summary>
    public class SeckillStockCacheHostedService : IHostedService
    {
        private readonly ISeckillStockCache seckillStockCache;

        public SeckillStockCacheHostedService(ISeckillStockCache seckillStockCache)
        {
            this.seckillStockCache = seckillStockCache;
        }

        /// <summary>
        /// 加载秒杀库存缓存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("加载秒杀库存到缓存中");
            return Task.Run(() => seckillStockCache.SkillStockToCache());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
