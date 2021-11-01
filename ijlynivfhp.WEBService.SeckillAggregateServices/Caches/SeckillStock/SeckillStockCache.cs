using Microsoft.Extensions.Caching.Memory;
using ijlynivfhp.WEBService.SeckillAggregateServices.Models.SeckillService;
using ijlynivfhp.WEBService.SeckillAggregateServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 秒杀库存缓存
    /// </summary>
    public class SeckillStockCache : ISeckillStockCache
    {
        /// <summary>
        /// 秒杀微服务客户端
        /// </summary>
        private readonly ISeckillsClient seckillsClient;
        /// <summary>
        /// 内存缓存
        /// </summary>
        private readonly IMemoryCache memoryCache;

        public SeckillStockCache(ISeckillsClient seckillsClient, IMemoryCache memoryCache)
        {
            this.seckillsClient = seckillsClient;
            this.memoryCache = memoryCache;
        }

        public int GetSeckillStocks(int ProductId)
        {
            Seckill seckillStock = memoryCache.Get<Seckill>(ProductId);
            return seckillStock.SeckillStock;
        }

        /// <summary>
        /// 秒杀库存加载到MemoryCache中
        /// </summary>
        public void SkillStockToCache()
        {
            // 1、查询所有秒杀活动
            List<Seckill> seckills = seckillsClient.GetSeckills();

            // 2、存储秒杀库存到缓存
            foreach (var seckill in seckills)
            {
                // 2.1 将所有秒杀活动存储到缓存中
                memoryCache.Set<Seckill>(seckill.ProductId, seckill);
            }
        }

        public void SubtractSeckillStock(int ProductId, int ProductCount)
        {
            // 1、获取秒杀活动信息
            Seckill seckill = memoryCache.Get<Seckill>(ProductId);

            // 2、扣减库存
            int SeckillStock = seckill.SeckillStock;
            SeckillStock = seckill.SeckillStock - ProductCount;
            seckill.SeckillStock = SeckillStock;

            // 3、更新库存
            memoryCache.Set<Seckill>(seckill.ProductId, seckill);

            Seckill seckill2 = memoryCache.Get<Seckill>(ProductId);
        }
    }
}
