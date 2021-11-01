using ijlynivfhp.Core.WEBService.OrderServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.OrderItemServices.Repositories
{
    /// <summary>
    /// 订单项仓储接口
    /// </summary>
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetOrderItems();
        OrderItem GetOrderItemById(int id);
        void Create(OrderItem OrderItem);
        void Update(OrderItem OrderItem);
        void Delete(OrderItem OrderItem);
        bool OrderItemExists(int id);
    }
}
