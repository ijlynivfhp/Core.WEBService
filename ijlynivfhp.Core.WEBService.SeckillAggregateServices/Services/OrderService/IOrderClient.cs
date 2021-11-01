using ijlynivfhp.Core.WEBService.Cores.Proxy;
using ijlynivfhp.Core.WEBService.Cores.Proxy.Attributes;
using ijlynivfhp.Core.WEBService.OrderServices.Models;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services
{
    /// <summary>
    /// 订单微服务客户端
    /// </summary>
    [MicroClient("http", "OrderServices")]
    public interface IOrderClient
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        [PostPath("/Orders")]
        public Order CreateOrder(Order order);
    }
}
