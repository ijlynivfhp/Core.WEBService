using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ijlynivfhp.Core.WEBService.ProductServices.Models;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Dto.SeckillService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Models.SeckillService;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Controllers
{
    /// <summary>
    /// 秒杀详情控制器
    /// </summary>
    [Route("api/SeckillDetail")]
    [ApiController]
    [Authorize] // 需要进行身份认证
    public class SeckillDetailController : ControllerBase
    {
        private readonly ISeckillsClient seckillsClient;
        private readonly IProductClient productClient;
        public SeckillDetailController(ISeckillsClient seckillsClient,
                                        IProductClient productClient)
        {
            this.seckillsClient = seckillsClient;
            this.productClient = productClient;
        }

        /// <summary>
        /// 查询秒杀详情
        /// </summary>
        /// <param name="id">秒杀编号</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public SeckillDto GetSeckill(int id)
        {
            // 1、秒杀活动
            Seckill seckill = seckillsClient.GetSeckill(id);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Seckill, SeckillDto>();
            });

            IMapper mapper = configuration.CreateMapper();

            SeckillDto seckillDto = mapper.Map<Seckill, SeckillDto>(seckill);
            // 2、查询秒杀商品信息
            Product product = productClient.GetProduct(seckill.ProductId);
            seckillDto.ProductPrice = product.ProductPrice;
            seckillDto.ProductDescription = product.ProductDescription;
            seckillDto.ProductTitle = product.ProductTitle;
            seckillDto.ProductUrl = product.ProductUrl;

            return seckillDto;
        }
    }
}
