using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ijlynivfhp.Core.WEBService.Commons.Users;
using ijlynivfhp.Core.WEBService.Cores.Cluster;
using ijlynivfhp.Core.WEBService.Cores.Middleware;
using ijlynivfhp.Core.WEBService.Cores.Middleware.transports;
using ijlynivfhp.Core.WEBService.Cores.Registry;
using ijlynivfhp.Core.WEBService.ProductServices.Models;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Dto.SeckillService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Models.SeckillService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Controllers
{
    /// <summary>
    /// 秒杀聚合控制器
    /// 1、资源在前，查询要求在后。seckill/1 主键 分页查询，时间查询，其他字段
    /// 2、资源在前，动词在后 seckill/page  seckill/bytimeid
    /// </summary>
    [Route("api/Seckill")] // 页面是资源 主语/getproduct主语/gettime  主语/1 // 1、header // 2、v1/主语/getproduct
    [ApiController]
    public class SeckillController : ControllerBase
    {
        private readonly ISeckillTimeClient seckillTimeClient;
        private readonly IProductClient productClient;
        private readonly ISeckillsClient seckillsClient;
        /*private readonly IMiddleService middleService;
        private readonly IServiceDiscovery serviceDiscovery;
        private readonly ILoadBalance loadBalance;*/
        /*private readonly IDynamicMiddleService dynamicMiddleService;
        private readonly OrderService orderService;*/
        public SeckillController(ISeckillTimeClient seckillTimeClient,
                                IProductClient productClient,
                                ISeckillsClient seckillsClient/*,
            IMiddleService middleService,
            IServiceDiscovery serviceDiscovery,
            ILoadBalance loadBalance*//*,
            IDynamicMiddleService dynamicMiddleService,
            OrderService orderService*/)
        {
            this.seckillTimeClient = seckillTimeClient;
            this.productClient = productClient;
            this.seckillsClient = seckillsClient;
            /*this.middleService = middleService;
            this.serviceDiscovery = serviceDiscovery;
            this.loadBalance = loadBalance;*/
            /*this.dynamicMiddleService = dynamicMiddleService;
            this.orderService = orderService;*/
        }

        /// <summary>
        /// 秒杀首页查询，秒杀时间查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SeckillTimeModel> GetSeckillIndex()
        {
            /* // 1、服务发现
             List<ServiceNode> serviceNodes = serviceDiscovery.Discovery("OrderServices");

             // 2、负载均衡(localhost:8008)
             ServiceNode serviceNode =  loadBalance.Select(serviceNodes);

             // 3、中台请求
             MiddleResult middleResult = middleService.Get("https"+serviceNode.Url +"/ddd", new Dictionary<string, object>());*/

         //  IList<object> listobjects = dynamicMiddleService.GetList<object>("https", "OrderServices", "/ddd", new Dictionary<string, object>());

          //  IList<object> vs = orderService.GetOrder("/ddd",new Dictionary<string,object>());
            // 1、查询秒杀时间
            List<SeckillTimeModel> seckillTimeModels = seckillTimeClient.GetSeckillTimes();

            // 2、对于秒杀时间进行过滤(2020/08/11 14:00  16:00) (2020/08/11 18:00) (2020/08/12 14:00)
            string data = DateTime.Now.ToShortDateString();
            string time = data + DateTime.Now.ToShortTimeString(); // 2020/09/12 21:17
            seckillTimeModels = seckillTimeModels.Where(s => string.Compare(data, s.SeckillDate, StringComparison.OrdinalIgnoreCase) <= 0
                                    && string.Compare(time, s.SeckillDate + s.SeckillEndtime, StringComparison.OrdinalIgnoreCase) < 0).ToList();
            return seckillTimeModels;
        }

        /// <summary>
        /// 秒杀时间编号查询秒杀活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{timeId}")]
        public List<SeckillDto> GetSeckills(int timeId)
        {
          /*  IList<object> vs = orderService.GetOrder("/ddd", new Dictionary<string, object>());

            IList<object> listobjects = dynamicMiddleService.GetList<object>("https", "OrderServices", "/ddd", new Dictionary<string, object>());*/
            // 1、秒杀活动
            List<Seckill> seckills = seckillTimeClient.GetSeckills(timeId);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Seckill, SeckillDto>();
            });

            IMapper mapper = configuration.CreateMapper();

            List<SeckillDto> seckillDtos = mapper.Map<List<Seckill>, List<SeckillDto>>(seckills);
            // 2、查询秒杀商品信息
            foreach (var seckill in seckillDtos)
            {
                Product product = productClient.GetProduct(seckill.ProductId);
                seckill.ProductPrice = product.ProductPrice;
                seckill.ProductDescription = product.ProductDescription;
                seckill.ProductTitle = product.ProductTitle;
                // seckill.ProductStock = product.ProductStock;
                seckill.ProductUrl = product.ProductUrl;
            }
            return seckillDtos;
        }

    }
}
