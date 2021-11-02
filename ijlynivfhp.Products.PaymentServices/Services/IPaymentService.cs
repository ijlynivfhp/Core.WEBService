using ijlynivfhp.Projects.PaymentServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.PaymentServices.Services
{
    /// <summary>
    /// 订单服务接口
    /// </summary>
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPaymentById(int id);
        void Create(Payment Payment);
        void Update(Payment Payment);
        void Delete(Payment Payment);
        bool PaymentExists(int id);
    }
}
