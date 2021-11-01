using ijlynivfhp.WEBService.Cores.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Services
{
    /// <summary>
    /// orderservice可以理解吗
    /// </summary>
    public class OrderService
    {
        private string scheme = "https";
        private string orderservice = "OrderService";
        private readonly IDynamicMiddleService dynamicMiddleService;
        public OrderService(IDynamicMiddleService dynamicMiddleService)
        {
            this.dynamicMiddleService = dynamicMiddleService;
        }
        
        public IList<object> GetOrder(string servicelink, IDictionary<string, object> paramsObject)
        {
            IList<object> listobjects = dynamicMiddleService.GetList<object>(scheme, orderservice, servicelink, paramsObject);

            return listobjects;
        }


    }
}
