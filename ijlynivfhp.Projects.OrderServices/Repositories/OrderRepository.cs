using ijlynivfhp.Projects.OrderServices.Context;
using ijlynivfhp.Projects.OrderServices.Models;
using ijlynivfhp.Projects.OrderServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ijlynivfhp.MicroService.OrderService.Repositories
{
    /// <summary>
    /// 订单仓储实现
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        public OrderContext OrderContext;
        public OrderRepository(OrderContext OrderContext)
        {
            this.OrderContext = OrderContext;
        }
        public void Create(Order Order)
        {
            OrderContext.Orders.Add(Order);
            OrderContext.SaveChanges();
        }

        public void Delete(Order Order)
        {
            OrderContext.Orders.Remove(Order);
            OrderContext.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return OrderContext.Orders.Find(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return OrderContext.Orders.ToList();
        }

        public void Update(Order Order)
        {
            OrderContext.Orders.Update(Order);
            OrderContext.SaveChanges();
        }
        public bool OrderExists(int id)
        {
            return OrderContext.Orders.Any(e => e.Id == id);
        }
    }
}
