using ijlynivfhp.Core.WEBService.OrderServices.Models;
using ijlynivfhp.Core.WEBService.OrderServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.OrderServices.Services
{
    /// <summary>
    /// 订单服务实现
    /// </summary>
    public class OrderServiceImpl : IOrderService
    {
        public readonly IOrderRepository OrderRepository;

        public OrderServiceImpl(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }

        public void Create(Order Order)
        {
            OrderRepository.Create(Order);
        }

        public void Delete(Order Order)
        {
            OrderRepository.Delete(Order);
        }

        public Order GetOrderById(int id)
        {
            return OrderRepository.GetOrderById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return OrderRepository.GetOrders();
        }

        public void Update(Order Order)
        {
            OrderRepository.Update(Order);
        }

        public bool OrderExists(int id)
        {
            return OrderRepository.OrderExists(id);
        }
    }
}
