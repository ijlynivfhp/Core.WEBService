using ijlynivfhp.Projects.Cores.Proxy;
using ijlynivfhp.Projects.Cores.Proxy.Attributes;
using ijlynivfhp.Projects.PaymentServices.Models;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Services
{
    /// <summary>
    /// 支付微服务客户端
    /// </summary>
    [MicroClient("https", "PaymentServices")]
    public interface IPaymentClient
    {
        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="payment"></param>
        [PostPath("/Payments")]
        public Payment Pay(Payment payment);
    }
}
