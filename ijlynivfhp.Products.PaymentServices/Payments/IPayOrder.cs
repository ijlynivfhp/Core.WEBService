﻿using System.Collections.Generic;

namespace ijlynivfhp.Projects.PaymentServices.Payments
{
    /// <summary>
    /// 支付订单接口
    /// </summary>
    interface IPayOrder
    {
        /// <summary>
        /// 支付订单查询
        /// </summary>
        /// <param name="order_sn">订单号</param>
        /// <returns></returns>
        public IDictionary<string, object> OrderQuery(string order_sn);

        /// <summary>
        /// 支付订单查询
        /// </summary>
        /// <param name="request_map">订单查询参数</param>
        /// <returns></returns>
        public IDictionary<string, object> OrderQuery(IDictionary<string, object> request_map);

        /// <summary>
        /// 支付订单关闭
        /// </summary>
        /// <param name="order_sn">订单号</param>
        /// <returns></returns>
        public IDictionary<string, object> CloseOrder(string order_sn);
    }
}
