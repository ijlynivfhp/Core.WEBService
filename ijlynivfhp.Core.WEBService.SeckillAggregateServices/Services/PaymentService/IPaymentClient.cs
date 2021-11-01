using ijlynivfhp.Core.WEBService.Cores.Proxy;
using ijlynivfhp.Core.WEBService.Cores.Proxy.Attributes;
using ijlynivfhp.Core.WEBService.PaymentServices.Models;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services
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
