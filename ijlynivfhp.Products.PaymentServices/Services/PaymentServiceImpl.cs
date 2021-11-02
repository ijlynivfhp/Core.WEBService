using ijlynivfhp.Projects.PaymentServices.Models;
using ijlynivfhp.Projects.PaymentServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.PaymentServices.Services
{
    /// <summary>
    /// 支付服务实现
    /// </summary>
    public class PaymentServiceImpl : IPaymentService
    {
        public readonly IPaymentRepository PaymentRepository;

        public PaymentServiceImpl(IPaymentRepository PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Create(Payment Payment)
        {
            PaymentRepository.Create(Payment);
        }

        public void Delete(Payment Payment)
        {
            PaymentRepository.Delete(Payment);
        }

        public Payment GetPaymentById(int id)
        {
            return PaymentRepository.GetPaymentById(id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return PaymentRepository.GetPayments();
        }

        public void Update(Payment Payment)
        {
            PaymentRepository.Update(Payment);
        }

        public bool PaymentExists(int id)
        {
            return PaymentRepository.PaymentExists(id);
        }
    }
}
