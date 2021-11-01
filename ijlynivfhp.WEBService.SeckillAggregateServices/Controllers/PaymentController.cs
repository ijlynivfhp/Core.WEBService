using Microsoft.AspNetCore.Mvc;
using ijlynivfhp.WEBService.PaymentServices.Models;
using ijlynivfhp.WEBService.SeckillAggregateServices.Pos.PaymentService;
using ijlynivfhp.WEBService.SeckillAggregateServices.Services;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Controllers
{
    /// <summary>
    /// 支付控制器
    /// </summary>
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentClient paymentClient;

        public PaymentController(IPaymentClient paymentClient)
        {
            this.paymentClient = paymentClient;
        }

        [HttpPost]
        public Payment Post([FromForm] PaymentPo paymentPo)
        {
            // 1、支付信息
            Payment payment = new Payment();
            payment.PaymentType = paymentPo.PaymentType;
            payment.OrderId = paymentPo.OrderId;
            payment.PaymentPrice = paymentPo.OrderTotalPrice;
            payment.OrderSn = paymentPo.OrderSn;
            payment.UserId = 1;

            // 2、创建支付订单
            payment = paymentClient.Pay(payment);

            return payment;
        }
    }
}
