﻿using ijlynivfhp.Projects.Cores.Proxy;
using ijlynivfhp.Projects.Cores.Proxy.Attributes;
using ijlynivfhp.Projects.SeckillAggregateServices.Models.SeckillService;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Services
{
    /// <summary>
    /// 秒杀微服务客户端
    /// </summary>
    [MicroClient("https", "SeckillServices")]
    public interface ISeckillsClient
    {
        /// <summary>
        /// 查询秒杀活动集合
        /// </summary>
        /// <returns></returns>
        [GetPath("/Seckills")]
        public List<Seckill> GetSeckills();

        /// <summary>
        /// 根据秒杀Id查询秒杀活动
        /// </summary>
        /// <param name="seckillId"></param>
        /// <returns></returns>
        [GetPath("/Seckills/{seckillId}")]
        public Seckill GetSeckill(int seckillId);

        /// <summary>
        /// 查询秒杀活动，通过时间条件查询
        /// </summary>
        /// <returns></returns>
        [GetPath("/Seckills/GetList")]
        public List<Seckill> GetSeckillsByTimeId(string TimeId);

        // <summary>
        /// 扣减秒杀库存
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductCount"></param>
        /// <returns></returns>
        [PutPath("/Seckills/set-stock")]
        public void SeckillSetStock(int ProductId, int ProductCount);

    }
}
