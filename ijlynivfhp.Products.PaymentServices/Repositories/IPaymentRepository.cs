using ijlynivfhp.Projects.PaymentServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.PaymentServices.Repositories
{
    /// <summary>
    /// 支付仓储接口
    /// </summary>
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPaymentById(int id);
        void Create(Payment Payment);
        void Update(Payment Payment);
        void Delete(Payment Payment);
        bool PaymentExists(int id);
    }
}
