using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ijlynivfhp.WEBService.SeckillServices.Models;
using ijlynivfhp.WEBService.SeckillServices.Services;
using ijlynivfhp.WEBService.SeckillTimeServices.Services;
using System.Collections.Generic;
using System.Linq;

namespace ijlynivfhp.WEBService.SeckillTimeModelServices.Controllers
{
    /// <summary>
    /// 秒杀时间服务控制器
    /// </summary>
    [Route("SeckillTimeModels")]
    [ApiController]
    public class SeckillTimeModelsController : ControllerBase
    {
        private readonly ISeckillTimeModelService SeckillTimeModelService;
        private readonly ISeckillService SeckillService;

        public SeckillTimeModelsController(ISeckillTimeModelService SeckillTimeModelService,
                                            ISeckillService SeckillService)
        {
            this.SeckillTimeModelService = SeckillTimeModelService;
            this.SeckillService = SeckillService;
        }

        // GET: api/SeckillTimeModels
        [HttpGet]
        public ActionResult<IEnumerable<SeckillTimeModel>> GetSeckillTimeModels()
        {
            return SeckillTimeModelService.GetSeckillTimeModels().ToList();
        }

        // GET: api/SeckillTimeModels/5
        [HttpGet("{id}")]
        public ActionResult<SeckillTimeModel> GetSeckillTimeModel(int id)
        {
            var SeckillTimeModel = SeckillTimeModelService.GetSeckillTimeModelById(id);

            if (SeckillTimeModel == null)
            {
                return NotFound();
            }

            return SeckillTimeModel;
        }

        /// <summary>
        /// 根据时间编号秒杀活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{timeId}/Seckills")]
        public ActionResult<IEnumerable<Seckill>> GetSeckills(int timeId)
        {
            Seckill seckill = new Seckill();
            seckill.TimeId = timeId;
            var seckills = SeckillService.GetSeckills(seckill).ToList();

            return seckills;
        }


        // PUT: api/SeckillTimeModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutSeckillTimeModel(int id, SeckillTimeModel SeckillTimeModel)
        {
            if (id != SeckillTimeModel.Id)
            {
                return BadRequest();
            }

            try
            {
                SeckillTimeModelService.Update(SeckillTimeModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeckillTimeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SeckillTimeModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<SeckillTimeModel> PostSeckillTimeModel(SeckillTimeModel SeckillTimeModel)
        {
            SeckillTimeModelService.Create(SeckillTimeModel);
            return CreatedAtAction("GetSeckillTimeModel", new { id = SeckillTimeModel.Id }, SeckillTimeModel);
        }

        // DELETE: api/SeckillTimeModels/5
        [HttpDelete("{id}")]
        public ActionResult<SeckillTimeModel> DeleteSeckillTimeModel(int id)
        {
            var SeckillTimeModel = SeckillTimeModelService.GetSeckillTimeModelById(id);
            if (SeckillTimeModel == null)
            {
                return NotFound();
            }

            SeckillTimeModelService.Delete(SeckillTimeModel);
            return SeckillTimeModel;
        }

        private bool SeckillTimeModelExists(int id)
        {
            return SeckillTimeModelService.SeckillTimeModelExists(id);
        }
    }
}
