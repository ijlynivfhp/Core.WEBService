using Microsoft.Extensions.Caching.Memory;
using ijlynivfhp.WEBService.Commons.Exceptions;
using ijlynivfhp.WEBService.SeckillAggregateServices.Models.SeckillService;
using ijlynivfhp.WEBService.SeckillAggregateServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 秒杀库存redis缓存
    /// </summary>
    public class RedisSeckillStockCache : ISeckillStockCache
    {
        /// <summary>
        /// 秒杀微服务客户端
        /// </summary>
        private readonly ISeckillsClient seckillsClient;
        private readonly IMemoryCache memoryCache;

        public RedisSeckillStockCache(ISeckillsClient seckillsClient, IMemoryCache memoryCache)
        {
            this.seckillsClient = seckillsClient;
            this.memoryCache = memoryCache;
        }

        public int GetSeckillStocks(int ProductId)
        {
           return Convert.ToInt32(RedisHelper.HGet(Convert.ToString(ProductId), "SeckillStock"));
        }

        /// <summary>
        /// 秒杀库存加载到redis中
        /// </summary>
        public void SkillStockToCache()
        {
            // 1、查询所有秒杀活动
            List<Seckill> seckills = seckillsClient.GetSeckills();

            // 2、加载秒杀商品
            foreach (var seckill in seckills)
            {
                // 3、存数秒杀库存
                bool flag = RedisHelper.HSet(Convert.ToString(seckill.ProductId), "SeckillStock", seckill.SeckillStock);
                // 4、存储限制秒杀购买数量
                bool flag2 = RedisHelper.HSet(Convert.ToString(seckill.ProductId), "SeckillLimit", seckill.SeckillLimit);

                // 3.1 存储到redis失败
                /*if (!flag && !flag2)
                {
                    throw new BizException("redis存储数据失败");
                }*/

                // flag // flag2 判断key是否存在
            }
        }

        /// <summary>
        /// redis扣减库存
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductCount"></param>
        public void SubtractSeckillStock(int ProductId, int ProductCount)
        {
            // 1、判断库存是否扣减完成
            long seckillStock = RedisHelper.HIncrBy(Convert.ToString(ProductId), "SeckillStock", -ProductCount);
            if (seckillStock < 0)
            {
                throw new BizException("秒杀已结束");
            }
        }
    }
}
