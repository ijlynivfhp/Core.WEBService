using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Caches.SeckillStock
{
    /// <summary>
    /// 秒杀缓存接口
    /// </summary>
    public interface ISeckillStockCache
    {
        /// <summary>
        /// 秒杀库存加载到缓存中
        /// </summary>
        public void SkillStockToCache();

        /// <summary>
        /// 根据商品编号获取秒杀库存
        /// </summary>
        public int GetSeckillStocks(int ProductId);

        /// <summary>
        /// 扣减秒杀库存
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductCount"></param>
        public void SubtractSeckillStock(int ProductId, int ProductCount);
    }
}
