using ijlynivfhp.Projects.Cores.Proxy;
using ijlynivfhp.Projects.Cores.Proxy.Attributes;
using ijlynivfhp.Projects.OrderServices.Models;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Services
{
    /// <summary>
    /// 订单微服务客户端
    /// </summary>
    [MicroClient("https", "OrderServices")]   
    public interface IOrderClient
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        [PostPath("/Orders")]
        public Order CreateOrder(Order order);
    }
}
