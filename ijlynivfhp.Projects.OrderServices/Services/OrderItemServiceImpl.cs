using ijlynivfhp.Projects.OrderItemServices.Repositories;
using ijlynivfhp.Projects.OrderServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.OrderItemServices.Services
{
    /// <summary>
    /// 订单项服务实现
    /// </summary>
    public class OrderItemServiceImpl : IOrderItemService
    {
        public readonly IOrderItemRepository OrderItemRepository;

        public OrderItemServiceImpl(IOrderItemRepository OrderItemRepository)
        {
            this.OrderItemRepository = OrderItemRepository;
        }

        public void Create(OrderItem OrderItem)
        {
            OrderItemRepository.Create(OrderItem);
        }

        public void Delete(OrderItem OrderItem)
        {
            OrderItemRepository.Delete(OrderItem);
        }

        public OrderItem GetOrderItemById(int id)
        {
            return OrderItemRepository.GetOrderItemById(id);
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return OrderItemRepository.GetOrderItems();
        }

        public void Update(OrderItem OrderItem)
        {
            OrderItemRepository.Update(OrderItem);
        }

        public bool OrderItemExists(int id)
        {
            return OrderItemRepository.OrderItemExists(id);
        }
    }
}
