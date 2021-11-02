using ijlynivfhp.Projects.OrderServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.OrderServices.Repositories
{
    /// <summary>
    /// 订单仓储接口
    /// </summary>
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void Create(Order Order);
        void Update(Order Order);
        void Delete(Order Order);
        bool OrderExists(int id);
    }
}
