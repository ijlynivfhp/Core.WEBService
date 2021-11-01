using System;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.PaymentServices.Payments
{
    /// <summary>
    /// 支付接口
    /// </summary>
    interface IPay
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="RequestParam"></param>
        /// <returns></returns>
        public IDictionary<String, Object> CreateOrder(IDictionary<String, Object> RequestParam);
    }
}
