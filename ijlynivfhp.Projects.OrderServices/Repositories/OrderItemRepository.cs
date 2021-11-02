using ijlynivfhp.Projects.OrderItemServices.Repositories;
using ijlynivfhp.Projects.OrderServices.Context;
using ijlynivfhp.Projects.OrderServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace ijlynivfhp.MicroService.OrderItemService.Repositories
{
    /// <summary>
    /// 订单项仓储实现
    /// </summary>
    public class OrderItemRepository : IOrderItemRepository
    {
        public OrderContext OrderContext;
        public OrderItemRepository(OrderContext OrderContext)
        {
            this.OrderContext = OrderContext;
        }
        public void Create(OrderItem OrderItem)
        {
            OrderContext.OrderItems.Add(OrderItem);
            OrderContext.SaveChanges();
        }

        public void Delete(OrderItem OrderItem)
        {
            OrderContext.OrderItems.Remove(OrderItem);
            OrderContext.SaveChanges();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return OrderContext.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return OrderContext.OrderItems.ToList();
        }

        public void Update(OrderItem OrderItem)
        {
            OrderContext.OrderItems.Update(OrderItem);
            OrderContext.SaveChanges();
        }
        public bool OrderItemExists(int id)
        {
            return OrderContext.OrderItems.Any(e => e.Id == id);
        }
    }
}
