using ijlynivfhp.WEBService.PaymentServices.Context;
using ijlynivfhp.WEBService.PaymentServices.Models;
using ijlynivfhp.WEBService.PaymentServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RuanMou.MicroService.PaymentService.Repositories
{
    /// <summary>
    /// 支付仓储实现
    /// </summary>
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentContext PaymentContext;
        public PaymentRepository(PaymentContext PaymentContext)
        {
            this.PaymentContext = PaymentContext;
        }
        public void Create(Payment Payment)
        {
            PaymentContext.Payments.Add(Payment);
            PaymentContext.SaveChanges();
        }

        public void Delete(Payment Payment)
        {
            PaymentContext.Payments.Remove(Payment);
            PaymentContext.SaveChanges();
        }

        public Payment GetPaymentById(int id)
        {
            return PaymentContext.Payments.Find(id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return PaymentContext.Payments.ToList();
        }

        public void Update(Payment Payment)
        {
            PaymentContext.Payments.Update(Payment);
            PaymentContext.SaveChanges();
        }
        public bool PaymentExists(int id)
        {
            return PaymentContext.Payments.Any(e => e.Id == id);
        }
    }
}
