using ijlynivfhp.Core.WEBService.Cores.Proxy;
using ijlynivfhp.Core.WEBService.Cores.Proxy.Attributes;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Models.SeckillService;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services
{
    /// <summary>
    /// 秒杀记录客户端
    /// </summary>
    [MicroClient("http", "SeckillServices")]
    public interface ISeckillTimeClient
    {
        /// <summary>
        /// 查询秒杀时间表
        /// </summary>
        /// <returns></returns>
        [GetPath("/SeckillTimeModels")]
        public List<SeckillTimeModel> GetSeckillTimes();

        /// <summary>
        /// 根据时间查询秒杀活动
        /// </summary>
        /// <returns></returns>
        [GetPath("/SeckillTimeModels/{timeId}/Seckills")]
        public List<Seckill> GetSeckills([PathVariable("timeId")]int timeId);
    }
}
