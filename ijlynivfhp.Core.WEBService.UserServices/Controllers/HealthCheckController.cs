using Microsoft.AspNetCore.Mvc;

namespace RuanMou.MicroService.TeamService.Controllers
{
    [Route("HealthCheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/Teams
        [HttpGet]
        public ActionResult GetHealthCheck()
        {
            return Ok("连接正常");
        }
    }
}