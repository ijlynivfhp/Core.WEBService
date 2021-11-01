using ijlynivfhp.WEBService.OrderServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.OrderServices.Services
{
    /// <summary>
    /// 订单服务接口
    /// </summary>
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void Create(Order Order);
        void Update(Order Order);
        void Delete(Order Order);
        bool OrderExists(int id);
    }
}
